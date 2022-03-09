using Microsoft.Data.SqlClient;
using RolePlayingGame.Data.Abstract;
using RolePlayingGame.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayingGame.Data.Concrete.Ado.Repository
{
    public class PlayerRepositoryAdo
    {
        SqlConnection connection = new SqlConnection("Server=DESKTOP-LS0EKQ4;Database=RolePlayingGameDatabase;Trusted_Connection=True;");
        public PlayerRepositoryAdo()
        {
        }

        public Player Find(int playerId)
        {
            throw new NotImplementedException();
        }

        public List<Player> GetAll()
        {
            ConnectionControl();

            SqlCommand command = new SqlCommand("SELECT * FROM Players " , connection);

            List<Player> playerList = new List<Player>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Player newItem = new Player
                {
                    PlayerId = (int)reader["PlayerId"],
                    Username = Convert.ToString(reader["Username"]),
                    Email = Convert.ToString(reader["Email"]),
                    Password = Convert.ToString(reader["Password"]),
                };
                playerList.Add(newItem);

            }

            reader.Close();
            connection.Close();



            return playerList;

        }







        public Player Login(Player playerLogin)
        {
            throw new NotImplementedException();
        }

        public Player Register(Player playerRegister)
        {
            throw new NotImplementedException();
        }



        public void ConnectionControl()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }


    }
}
