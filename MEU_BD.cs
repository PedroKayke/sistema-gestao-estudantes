using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace sistema_gestao_estudantes
{
    // A classe do nosso banco de dados.
    internal class MEU_BD
    {
        // O "objeto" que representa a nossa conexão com o banco de dados.
        private MySqlConnection conexao = new MySqlConnection("datasource=localhost;username=root;password=;database=t4_sga_bd");
        
        public MySqlConnection getConexao
        {
            get
            { 
                return conexao; 
            }
        }

        public void abirConexao()
        {
            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }
        }

        public void fecharConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
