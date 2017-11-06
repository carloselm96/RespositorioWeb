﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Web.Models.Context
{
    public class PartidoContext
    {
        public PartidoContext(string cs)
        {
            ConnectionString = cs;
        }
        public string ConnectionString { get; set; }

        public List<Partido> getPartidos()
        {
            List<Partido> result = new List<Partido>();
            string cmdText = "select * from consulta_partidos ";            
            MySqlConnection my = new MySqlConnection(ConnectionString);
            my.Open();
            MySqlCommand command = new MySqlCommand(cmdText, my);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Partido partido = new Partido(); // Id_partido, Fecha, Hora, FK_disciplina, Nombre, contrincante1, contrincante2, Equipo1, Equipo2, Ubicacion
                partido.id = reader.GetInt16("Id_partido");
                partido.fecha_hora = reader.GetDateTime("Fecha");
                partido.disciplina = new Disciplina();
                partido.disciplina.id = reader.GetInt16("FK_disciplina");
                partido.disciplina.nombre = reader.GetString("Nombre");
                partido.equipo1 = new Equipo();
                partido.equipo2 = new Equipo();
                partido.equipo1.id = reader.GetInt16("Equipo1");
                partido.equipo2.id = reader.GetInt16("Equipo2");
                partido.equipo1.nombre = reader.GetString("contrincante1");
                partido.equipo2.nombre = reader.GetString("contrincante2");
                partido.ubicacion = new Ubicacion();
                partido.ubicacion.nombre = reader.GetString("ubicacion");
                partido.ubicacion.longitud = reader.GetString("longitud");
                partido.ubicacion.latitud = reader.GetString("Latitud");
                //department.dept_no = reader.GetString("dept_no");                
                result.Add(partido);
            }
            command.Dispose();
            my.Close();
            return result;
        }

        public Partido GetPartido(string id)
        {
            Partido partido = new Partido();
            string cmdText = "select * from consulta_partidos where Id_partido=@id;";
            MySqlConnection my = new MySqlConnection(ConnectionString);
            my.Open();


            using (MySqlCommand command = new MySqlCommand(cmdText, my))
            {
                command.Parameters.Add(new MySqlParameter("@id", id));

                var reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    partido.id = reader.GetInt16("Id_partido");
                    partido.fecha_hora = DateTime.Parse(reader.GetString("Fecha"), System.Globalization.CultureInfo.InvariantCulture);
                    partido.disciplina = new Disciplina();
                    partido.disciplina.id = reader.GetInt16("FK_disciplina");
                    partido.disciplina.nombre = reader.GetString("Nombre");
                    partido.equipo1 = new Equipo();
                    partido.equipo2 = new Equipo();
                    partido.equipo1.id = reader.GetInt16("Equipo1");
                    partido.equipo2.id = reader.GetInt16("Equipo2");
                    partido.equipo1.nombre = reader.GetString("contrincante1");
                    partido.equipo2.nombre = reader.GetString("contrincante2");
                    partido.ubicacion = new Ubicacion();
                    partido.ubicacion.nombre = reader.GetString("ubicacion");
                    partido.ubicacion.longitud = reader.GetString("longitud");
                    partido.ubicacion.latitud = reader.GetString("Latitud");
                }
            }

            my.Close();
            return partido;
        }
    }
}