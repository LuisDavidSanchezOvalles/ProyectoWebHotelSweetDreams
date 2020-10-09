﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetDreams.Api.DAL;
using SweetDreams.Api.Models.Administrador;

namespace SweetDreams.Api.Controllers
{
    [Route(template: "api/[Controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private Contexto contexto;

        public ClientesController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetList()
        {
            List<Clientes> Lista;
            try
            {
                Lista = await contexto.Clientes.Where(h => h.Accesibilidad == true).ToListAsync();
                Lista = Lista.Where(h => h.Accesibilidad == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


        private async Task<ActionResult<bool>> Insertar(Clientes cliente)
        {
            bool guardar = false;
            try
            {
                contexto.Clientes.Add(cliente);
                guardar = await contexto.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return guardar;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            bool eliminado = false;
            try
            {
                var Clientes = await contexto.Clientes.Where(d => d.ClienteId == id).SingleOrDefaultAsync();

                if (Clientes != null)
                {
                    Clientes.Accesibilidad = false;
                    contexto.Clientes.Update(Clientes);
                    //contexto.Clientes.Remove(Clientes);
                    eliminado = (await contexto.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eliminado;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> Buscar(int id)
        {
            Clientes cliente = new Clientes();
            try
            {
                var encontrado = await contexto.Clientes.FindAsync(id);

                if (encontrado == null)
                    return new Clientes();
                if (encontrado.Accesibilidad == false)
                    return new Clientes();
                else
                    cliente = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return cliente;
        }

        private async Task<ActionResult<bool>> Modificar([FromBody] Clientes cliente)
        {
            bool modificar = false;
            try
            {
                contexto.Clientes.Update(cliente);
                modificar = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return modificar;
        }

        private bool Existe(int id)
        {
            bool existe;
            try
            {
                existe = contexto.Clientes.Any(a => a.ClienteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Clientes cliente)
        {
            if (Existe(cliente.ClienteId))
                return await Modificar(cliente);
            else
                return await Insertar(cliente);
        }
    }
}
