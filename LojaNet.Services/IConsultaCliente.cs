using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LojaNet.Services
{
    [ServiceContract]
    public interface IConsultaCliente
    {
        [OperationContract]
        ClienteInfo ConsultarPorEmail(string chave, string email);

    }
}