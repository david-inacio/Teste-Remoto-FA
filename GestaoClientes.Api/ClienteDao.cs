using Dapper;
using GestaoClientes.Api.Helpers;
using GestaoClientes.Api.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GestaoClientes.Api
{

    public class ClienteDao
    {

        private string connection = ConfigurationManager.ConnectionStrings["GestaoClientesConexao"].ConnectionString;


        internal List<Cliente> GetClientes()
        {

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    string readSp = "SP_ListCliente";
                    return db.Query<Cliente>(readSp, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao executar a operação: " + ex.Message);
            }
        }


        internal List<ClienteSituacao> GetClienteSituacoes()
        {

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    string readSp = "SP_ListSituacaoCliente";
                    return db.Query<ClienteSituacao>(readSp, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao executar a operação: " + ex.Message);
            }
        }


        internal List<ClienteTipo> GetClienteTipos()
        {

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    string readSp = "SP_ListTipoCliente";
                    return db.Query<ClienteTipo>(readSp, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao executar a operação: " + ex.Message);
            }
        }


        internal void Create(Cliente cliente)
        {
            if (!CpfValidateHelper.IsValid(cliente.CPF))
            {
                throw new Exception("Cpf Inválido");
            }
            else if (GetClientes().Where(t => t.CPF == cliente.CPF).Any())
            {
                throw new Exception("Cpf já cadastrado no sistema.");
            }

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    string readSp = "SP_IncCliente";
                    db.Execute(readSp, new
                    {
                        cliente.Nome,
                        cliente.CPF,
                        cliente.Sexo,
                        cliente.TipoID,
                        cliente.SituacaoID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao executar a operação: " + ex.Message);
            }
        }


        internal Cliente GetCliente(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    string readSp = "SP_ConsCliente";
                    return db.Query<Cliente>(readSp, new { id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao executar a operação: " + ex.Message);
            }
        }


        internal void Update(Cliente cliente)
        {
            if (!CpfValidateHelper.IsValid(cliente.CPF))
            {
                throw new Exception("Cpf Inválido");
            }
            else if (GetClientes().Where(t => t.CPF == cliente.CPF).Any())
            {
                if (GetClientes().Where(t => t.CPF == cliente.CPF).FirstOrDefault().ID != cliente.ID)
                    throw new Exception("Cpf já cadastrado no sistema.");
            }

            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    string readSp = "SP_AltCliente";
                    db.Execute(readSp, new
                    {
                        cliente.ID,
                        cliente.Nome,
                        cliente.CPF,
                        cliente.Sexo,
                        cliente.TipoID,
                        cliente.SituacaoID
                    }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao executar a operação: " + ex.Message);
            }
        }


        internal void Delete(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    string readSp = "SP_DelCliente";
                    db.Execute(readSp, new { id = id }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao executar a operação: " + ex.Message);
            }
        }
    }
}
