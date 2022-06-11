using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace cs_project
{
    public class ShapesManagment
    {
        private SqlConnection sqlConnection = new SqlConnection();

        //Connection to DB
        private void connectionToDB()
        {
            //Query to Connect
            string sqlConnectionString = @"Server=localhost,1433;Database=db_shapes;User Id=sa;Password=123456789;MultipleActiveResultSets=True;";
            sqlConnection = new SqlConnection(sqlConnectionString);

            //open The Connection
            sqlConnection.Open();
        }

        //Menu
        public void menu()
        {

            //Menu To choose From
            Console.WriteLine("----- Shapes Managment ------");
            Console.WriteLine("\n\n\n");
            Console.WriteLine("1 - Display All Shapes");
            Console.WriteLine("2 - Fetch a Single Shapes");
            Console.WriteLine("3 - Add Shape");
            Console.WriteLine("4 - Edit Shape");
            Console.WriteLine("5 - Remove Shapes");
            Console.WriteLine("6 - Exit");
            Console.WriteLine("\n\n");

            Console.WriteLine("Choose : ");
            var input = Console.ReadLine();

            //Set a default value to choice in case user enter a non valide input
            int choice = 10;

            //check if the input is number
            if(int.TryParse(input, out choice) && choice >= 1 && choice <= 3)
            {
                choice = Convert.ToInt32(input);
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                    fetchAllShapes();
                    break;
                case 2:
                    fetchSingleShapes();
                    break;
                case 3:
                    addShapes();
                    break;
                case 4:
                    updateShapes();
                    break;
                case 5:
                    deleteShapes();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please Enter a valide choice from the list");
                    Console.WriteLine("\n\n\npress any key to restart...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        //add shapes
        public void addShapes()
        {
            //Connection to DB
            connectionToDB();

            //Write all the shape properties
            Console.WriteLine("Enter Width");
            float width = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Height");
            float height = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amoung of Side");
            int amoung_of_side = Convert.ToInt32(Console.ReadLine());

            //Position
            Console.WriteLine("Enter Position X");
            float position_x = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Position Y");
            float position_y = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Position Z");
            float position_z = float.Parse(Console.ReadLine());

            //Scale
            Console.WriteLine("Enter Scale");
            float scale = float.Parse(Console.ReadLine());

            //Rotation
            Console.WriteLine("Enter Rotation X");
            float rotation_x = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Rotation Y");
            float rotation_y = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Rotation Z");
            float rotation_z = float.Parse(Console.ReadLine());

            //Query String
            string insertQuery = "INSERT INTO shapes VALUES(@width, @height, @amoung_of_side, @position_x, @position_y, @position_z, @scale, @rotation_x, @rotation_y, @rotation_z)";

            //Query commande
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

            //Add all the value to Query
            insertCommand.Parameters.AddWithValue("@width", width);
            insertCommand.Parameters.AddWithValue("@height", height);
            insertCommand.Parameters.AddWithValue("@amoung_of_side", amoung_of_side);
            insertCommand.Parameters.AddWithValue("@position_x", position_x);
            insertCommand.Parameters.AddWithValue("@position_y", position_y);
            insertCommand.Parameters.AddWithValue("@position_z", position_z);
            insertCommand.Parameters.AddWithValue("@scale", scale);
            insertCommand.Parameters.AddWithValue("@rotation_x", rotation_x);
            insertCommand.Parameters.AddWithValue("@rotation_y", rotation_y);
            insertCommand.Parameters.AddWithValue("@rotation_z", rotation_z);

            //Excecute the Query
            insertCommand.ExecuteNonQuery();

            //close the connection
            sqlConnection.Close();

            Console.Clear();
            Console.WriteLine("Shapes has been added!");
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.Clear();
        }

        //Update Shapes
        public void updateShapes()
        {
            //Connection to DB
            connectionToDB();

            //Insert all the Shapes Information
            Console.WriteLine("Enter Shape ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Width");
            float width = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Height");
            float height = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amoung of Side");
            int amoung_of_side = Convert.ToInt32(Console.ReadLine());

            //Position
            Console.WriteLine("Enter Position X");
            float position_x = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Position Y");
            float position_y = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Position Z");
            float position_z = float.Parse(Console.ReadLine());

            //Scale
            Console.WriteLine("Enter Scale");
            float scale = float.Parse(Console.ReadLine());

            //Rotation
            Console.WriteLine("Enter Rotation X");
            float rotation_x = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Rotation Y");
            float rotation_y = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Rotation Z");
            float rotation_z = float.Parse(Console.ReadLine());

            //Query to Update
            string updateQuery = "UPDATE shapes set width=@width, height=@height, amoung_of_side=@amoung_of_side, position_x=@position_x, position_y=@position_y, position_z=@position_z, scale=@scale, rotation_x=@rotation_x, rotation_y=@rotation_y, rotation_z=@rotation_z WHERE id=@id";

            //Execute the query
            SqlCommand insertCommand = new SqlCommand(updateQuery, sqlConnection);

            //Insert all the input to the commande
            insertCommand.Parameters.AddWithValue("@width", width);
            insertCommand.Parameters.AddWithValue("@height", height);
            insertCommand.Parameters.AddWithValue("@amoung_of_side", amoung_of_side);
            insertCommand.Parameters.AddWithValue("@position_x", position_x);
            insertCommand.Parameters.AddWithValue("@position_y", position_y);
            insertCommand.Parameters.AddWithValue("@position_z", position_z);
            insertCommand.Parameters.AddWithValue("@scale", scale);
            insertCommand.Parameters.AddWithValue("@rotation_x", rotation_x);
            insertCommand.Parameters.AddWithValue("@rotation_y", rotation_y);
            insertCommand.Parameters.AddWithValue("@rotation_z", rotation_z);
            insertCommand.Parameters.AddWithValue("@id", id);

            //Excecute the query
            insertCommand.ExecuteNonQuery();

            //Close DB connection
            sqlConnection.Close();

            Console.Clear();
            Console.WriteLine("Shapes has been Updated!");
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.Clear();

        }

        //Delete Shapes
        public void deleteShapes()
        {
            //Connection to DB
            connectionToDB();

            //Select which ID need to be Deleted!
            Console.WriteLine("Please Enter The Shape ID you want to Delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            //Query String
            string deleteQuery = "DELETE shapes WHERE id=@id";
            SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);

            //Query Excecute
            sqlCommand.ExecuteNonQuery();

            //Close the Connection with DB
            sqlConnection.Close();

            Console.Clear();
            Console.WriteLine("ID has Been Deleted");
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.Clear();

        }

        //Display All Shapes
        public void fetchAllShapes()
        {
            //Connection to DB
            connectionToDB();

            string fetchAllQuery = "SELECT * FROM shapes";
            SqlCommand sqlCommand = new SqlCommand(fetchAllQuery, sqlConnection);
            SqlDataReader data = sqlCommand.ExecuteReader();

            //list to store our rotation and position Object
            List<string> positionlist = new List<string>();
            List<string> rotationlist = new List<string>();

            // check if data Exist
            bool checkData = true;

            while (data.Read())
            {

                checkData = false;
                for (var i = 4; i < 7; i++)
                {
                    positionlist.Add(data.GetValue(i).ToString());
                }

                for (int i = 8; i < 11; i++)
                {
                    rotationlist.Add(data.GetValue(i).ToString());
                }

                //Convert List To array
                string[] position = positionlist.ToArray();
                string[] rotation = rotationlist.ToArray();

                Console.WriteLine("ID: " + data.GetValue(0).ToString());
                Console.WriteLine("Width: " + data.GetValue(1).ToString());
                Console.WriteLine("Height: " + data.GetValue(2).ToString());
                Console.WriteLine("Amoung of Side: " + data.GetValue(3).ToString());
                Console.Write("Position: ");
                foreach (var pos in position)
                {
                    Console.Write(pos.ToString() + " ");
                }
                Console.WriteLine("\nScale: " + data.GetValue(7).ToString());
                Console.Write("Rotation: ");
                foreach (var rot in rotation)
                {
                    Console.Write(rot.ToString() + " ");
                }
                Console.WriteLine("\n\n");

                //Clear our List for position and rotation
                positionlist.Clear();
                rotationlist.Clear();
            }

            if (checkData)
            {
                Console.WriteLine("\n");
                Console.WriteLine("No Data try Another Valide ID");
                Console.Write("\n\n\nPress any Key To restart");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.Write("Press any Key:  ");
                Console.ReadKey();
                Console.Clear();
            }

            //Close connection with DB
            sqlConnection.Close();

        }

        //Fetch Single Shapes
        public void fetchSingleShapes()
        {
            //Connection to DB
            connectionToDB();

            Console.Write("What Shape you want to fetch: ");
            int id = Convert.ToInt32(Console.ReadLine());
            string fetchSingleQuery = "SELECT * FROM shapes WHERE id=@id";
            SqlCommand sqlCommand = new SqlCommand(fetchSingleQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            SqlDataReader data = sqlCommand.ExecuteReader();

            //list to store our rotation and position Object
            List<string> positionlist = new List<string>();
            List<string> rotationlist = new List<string>();

            //to check if data exist
            bool checkData = true;

            while (data.Read())
            {
                checkData = false;
                for (var i = 4; i < 7; i++)
                {
                    positionlist.Add(data.GetValue(i).ToString());
                }

                for (int i = 8; i < 11; i++)
                {
                    rotationlist.Add(data.GetValue(i).ToString());
                }

                //Convert List To array
                string[] position = positionlist.ToArray();
                string[] rotation = rotationlist.ToArray();

                Console.WriteLine("ID: " + data.GetValue(0).ToString());
                Console.WriteLine("Width: " + data.GetValue(1).ToString());
                Console.WriteLine("Height: " + data.GetValue(2).ToString());
                Console.WriteLine("Amoung of Side: " + data.GetValue(3).ToString());
                Console.Write("Position: ");
                foreach (var pos in position)
                {
                    Console.Write(pos.ToString() + " ");
                }
                Console.WriteLine("\nScale: " + data.GetValue(7).ToString());
                Console.Write("Rotation: ");
                foreach (var rot in rotation)
                {
                    Console.Write(rot.ToString() + " ");
                }

            }

            if (checkData)
            {
                Console.WriteLine("\n");
                Console.WriteLine("No Data try Another Valide ID");
                Console.Write("\n\n\nPress any Key To restart");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.Write("Press any Key:  ");
                Console.ReadKey();
                Console.Clear();
            }

            //Close connection with DB
            sqlConnection.Close();
        }
    }
}
