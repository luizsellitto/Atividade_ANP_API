using Atividade_ANP_API.Models;
using Atividade_ANP_API.Dtos;
using static Atividade_ANP_API.Repositories.ClienteRepository;
using System.Reflection.Metadata.Ecma335;

namespace Atividade_ANP_API.Repositories
{
        public class ClienteRepository
        {
            private const string caminho = "C:/Users/luizs/OneDrive/Documentos/GitHub/Atividade_ANP_API/Cliente.txt";

            public static IEnumerable<Cliente> Listar()
            {
                var clientes = new List<Cliente>();

                if (File.Exists(caminho))
                {
                    var lines = File.ReadAllLines(caminho);
                    foreach (var line in lines)
                    {
                        var dado = line.Split('|');
                        var cliente = new Cliente
                        {
                            Id = int.Parse(dado[0]),
                            Nome = dado[1],
                            DataNascimento = dado[2],
                            Sexo = dado[3],
                            RG = dado[4],
                            CPF = dado[5],
                            Endereco = dado[6],
                            Cidade = dado[7],
                            Estado = dado[8],
                            Telefone = dado[9],
                            Email = dado[10]
                        };
                        clientes.Add(cliente);
                    }
                }

                return clientes;
            }

            public static Cliente GetById(int id)
            {
                return Listar().FirstOrDefault(c => c.Id == id);
            }

            public static Cliente GetByCPF(string cpf)
            {
                return Listar().FirstOrDefault(c => c.CPF == cpf);
            }

            public static Cliente Criar(ClienteDto clienteDto)
            {
                var maiorId = 0;
                foreach (var a in Listar())
                {
                    if (a.Id > maiorId)
                    {
                        maiorId = a.Id;
                    }
                }
                var cliente = new Cliente
                {
                    Id = maiorId + 1,
                    Nome = clienteDto.Nome,
                    DataNascimento = clienteDto.DataNascimento,
                    Sexo = clienteDto.Sexo,
                    RG = clienteDto.RG,
                    CPF = clienteDto.CPF,
                    Endereco = clienteDto.Endereco,
                    Cidade = clienteDto.Cidade,
                    Estado = clienteDto.Estado,
                    Telefone = clienteDto.Telefone,
                    Email = clienteDto.Email
                };
                using (var writer = new StreamWriter(caminho, true)) //Diferença entre true e false é que o false apaga
                {
                    var line = $"{cliente.Id}|{cliente.Nome}|{cliente.DataNascimento}|{cliente.Sexo}|{cliente.RG}|{cliente.CPF}|{cliente.Endereco}|{cliente.Cidade}|{cliente.Estado}|{cliente.Telefone}|{cliente.Email}";
                    writer.WriteLine(line);
                }
                return cliente;
            }


            public static Cliente Atualizar(int id, ClienteDto clienteDto)
            {
                var clientes = Listar().ToList();
                var existingCliente = clientes.FirstOrDefault(c => c.Id == id);
                if (existingCliente == null) return null;

                var clienteAtualizado = new Cliente
                {
                    Id = id,
                    Nome = clienteDto.Nome,
                    DataNascimento = clienteDto.DataNascimento,
                    Sexo = clienteDto.Sexo,
                    RG = clienteDto.RG,
                    CPF = clienteDto.CPF,
                    Endereco = clienteDto.Endereco,
                    Cidade = clienteDto.Cidade,
                    Estado = clienteDto.Estado,
                    Telefone = clienteDto.Telefone,
                    Email = clienteDto.Email
                };

                clientes.Remove(existingCliente);
                clientes.Add(clienteAtualizado);
                SalvarTxt(clientes);
                return clienteAtualizado;
            }

            public static bool Deletar(int id)
            {
                var clientes = Listar().ToList();
                var cliente = clientes.FirstOrDefault(c => c.Id == id);
                if (cliente == null) return false;

                clientes.Remove(cliente);
                SalvarTxt(clientes);
                return true;
            }

            private static void SalvarTxt(List<Cliente> clientes)
            {
                using (var writer = new StreamWriter(caminho, false)) //Se colocar true, sempre vai adicionar uma lista igual
                {
                    foreach (var cliente in clientes)
                    {
                        var line = $"{cliente.Id}|{cliente.Nome}|{cliente.DataNascimento}|{cliente.Sexo}|{cliente.RG}|{cliente.CPF}|{cliente.Endereco}|{cliente.Cidade}|{cliente.Estado}|{cliente.Telefone}|{cliente.Email}";
                        writer.WriteLine(line);
                    }
                }
            }

        }
}
