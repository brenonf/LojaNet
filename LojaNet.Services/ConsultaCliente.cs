using LojaNet.BLL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LojaNet.Services
{
    public class ConsultaCliente : IConsultaCliente
    {
        private readonly IConfiguration _configuration;

        public ConsultaCliente(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ClienteInfo ConsultarPorEmail(string chave, string email)
        {
            if (chave != "1234567890@!")
            {
                return null;
            }

            ClienteInfo clienteInfo = null;
            //var dal = new ClienteDAL();

            ClienteBLL bll = new ClienteBLL(_configuration);
            var cliente = bll.ObterPorEmail(email);

            if (cliente == null)
            {
                return null;
            }
            else
            {
                clienteInfo = new ClienteInfo()
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone

                };
            }

            return clienteInfo;

        }
    }
}