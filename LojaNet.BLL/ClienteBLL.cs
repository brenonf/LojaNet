﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;
using LojaNet.DAL;
using Microsoft.Extensions.Configuration;

namespace LojaNet.BLL
{
    public class ClienteBLL : IClienteDados
    {
        private IClienteDados dal;
        public ClienteBLL(IConfiguration configuration)
        {
            this.dal = new ClienteDAL(configuration);
        }

        public ClienteBLL(IClienteDados clienteDados)
        {
            this.dal = clienteDados;
        }

        public void Alterar(Cliente cliente)
        {
            Validar(cliente);
            if (string.IsNullOrEmpty(cliente.Id))
            {
                throw new Exception("O Id deve ser informado!");
            }
            dal.Alterar(cliente);
        }

        public void Excluir(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new Exception("O Id deve ser informado!");
            }
            dal.Excluir(Id);
        }

        public void Incluir(Cliente cliente)
        {
            Validar(cliente);
            if (string.IsNullOrEmpty(cliente.Id))
            {
                cliente.Id = Guid.NewGuid().ToString();
            }
            dal.Incluir(cliente);
        }

        private static void Validar(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ApplicationException("O nome deve ser informado.");
            }
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string Id)
        {
            return dal.ObterPorId(Id);
        }

        public List<Cliente> ObterTodos()
        {
            var lista = dal.ObterTodos();
            return lista;
        }
    }
}