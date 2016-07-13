using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HospitalApp.Data
{
    class Repository
    {
        private SqlConnection SqlConnection { get; set; }
        private string ConnectionString { get; set; }
        private DataTable DataTable { get; set; }
        private SqlDataAdapter SqlDataAdapter { get; set; }
        private DataSet DataSet { get; set; }
        private SqlCommand SqlCommand { get; set; }

        public Repository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["HospitalModelVersion1Container"].ConnectionString;
            SqlConnection = new SqlConnection(ConnectionString);
            //SqlConnection = new SqlConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["HospitalModelVersion1Container"].ConnectionString };
        }

        public List<Doctor> SelecDoctor(string Query)
        {
            SqlDataAdapter = new SqlDataAdapter(Query, SqlConnection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);

            return DataTable.AsEnumerable().Select(r => new Doctor
            {
                Id = (Guid)r["Id"],
                FIO = (string)r["FIO"],
                PositionId = (Guid)r["PositionId"],
                PhoneNumber = (string)r["PhoneNumber"],
                //Position = (string)r["PositionName"]
            }).ToList();

        }

        public List<Customer> SelectCustomers(string Query)
        {
            SqlDataAdapter = new SqlDataAdapter(Query, SqlConnection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            return DataTable.AsEnumerable().Select(r => new Customer
            {
                Id = (Guid)r["Id"],
                FIO = (string)r["FIO"],
                PhoneNumber = (string)r["PhoneNumber"],
                BirthDate = (DateTime)r["BirthDate"],
                EnsuranceNumber = (string)r["EnsuranceNumber"],
            }).ToList();

        }

        public List<Position> SelectPosition(string Query)
        {
            SqlDataAdapter = new SqlDataAdapter(Query, SqlConnection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);

            return DataTable.AsEnumerable().Select(r => new Position
            {
                Id = (Guid)r["Id"],
                PositionName = (string)r["PositionName"],
                //Position = (string)r["PositionName"]
            }).ToList();
        }

        public List<Appointment> SelectAppointment(string Query)
        {
            SqlDataAdapter = new SqlDataAdapter(Query, SqlConnection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);

            return DataTable.AsEnumerable().Select(r => new Appointment
            {
                Id = (Guid)r["Id"],
                DoctorId = (Guid)r["DoctorId"],
                CustomerId = (Guid)r["CustomerId"],
            }).ToList();
        }

        public List<Bill> SelectBills(string Query)
        {
            SqlDataAdapter = new SqlDataAdapter(Query, SqlConnection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);

            return DataTable.AsEnumerable().Select(r => new Bill
            {
                Id = (Guid)r["Id"],
                AppointmentId = (Guid)r["AppointmentId"],
                ServiceId = (Guid)r["ServiceId"],
            }).ToList();
        }

        public List<Schedule> SelectSchedule(string Query)
        {
            SqlDataAdapter = new SqlDataAdapter(Query, SqlConnection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);

            return DataTable.AsEnumerable().Select(r => new Schedule
            {
                Id = (Guid)r["Id"],
                DoctorId = (Guid)r["DoctorId"],
                WeekDay = (string)r["WeekDay"],
                DayBegin = (DateTime)r["DayBegin"],
                DayEnd = (DateTime)r["DayEnd"],
            }).ToList();
        }

        public List<Service> SelectService(string Query)
        {
            SqlDataAdapter = new SqlDataAdapter(Query, SqlConnection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);

            return DataTable.AsEnumerable().Select(r => new Service
            {
                Id = (Guid)r["Id"],
                Cost = (decimal)r["Cost"],
                ServiceName = (string)r["ServiceName"],
            }).ToList();
        }

        public void InsertIntoDoctors(Doctor doctor)
        {
            //SqlDataAdapter = new SqlDataAdapter(Query, SqlConnection);
            //DataSet = new DataSet();
            //SqlDataAdapter.Fill(DataSet);
            SqlCommand = new SqlCommand("InsertIntoDoctors", SqlConnection);
            SqlCommand.CommandType = CommandType.StoredProcedure;
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DoctorId",
                DbType = DbType.Guid,
                Value = doctor.Id
            });
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DoctorFIO",
                DbType = DbType.String,
                Value = doctor.FIO
            });
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DoctorPhoneNumber",
                DbType = DbType.String,
                Value = doctor.PhoneNumber
            });
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@PositionId",
                DbType = DbType.Guid,
                Value = doctor.Position.Id
            });
            //SqlCommand.Parameters.Add(new SqlParameter()
            //{
            //    ParameterName = "@PositionNamePosition",
            //    DbType = DbType.String,
            //    Value = doctor.Position.PositionName
            //});
            SqlConnection.Open();
            SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
        }

        public void InsertIntoSchedules(Schedule schedule)
        {
            SqlCommand = new SqlCommand("InsertIntoSchedules", SqlConnection);
            SqlCommand.CommandType = CommandType.StoredProcedure;
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@ScheduleId",
                DbType = DbType.Guid,
                Value = schedule.Id
            });
            SqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@DoctorId",
                DbType = DbType.Guid,
                Value = schedule.DoctorId
            });
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@WeekDay",
                DbType = DbType.String,
                Value = schedule.WeekDay
            });
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DayBegin",
                DbType = DbType.DateTime,
                Value = schedule.DayBegin
            });
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@DayEnd",
                DbType = DbType.DateTime,
                Value = schedule.DayEnd
            });
            SqlConnection.Open();
            SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
        }

        public void InsertIntoPositions(Position position)
        {
            SqlCommand = new SqlCommand("InsertIntoPositions", SqlConnection);
            SqlCommand.CommandType = CommandType.StoredProcedure;
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                DbType = DbType.Guid,
                Value = position.Id
            });
            SqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@PositionName",
                DbType = DbType.String,
                Value = position.PositionName
            });
            SqlConnection.Open();
            SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();

        }

        public void InsertIntoServices(Service service)
        {
            SqlCommand = new SqlCommand("InsertIntoServices", SqlConnection);
            SqlCommand.CommandType = CommandType.StoredProcedure;
            SqlCommand.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Id",
                DbType = DbType.Guid,
                Value = service.Id
            });
            SqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@ServiceName",
                DbType = DbType.String,
                Value = service.ServiceName
            });
            SqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "@Cost",
                DbType = DbType.Decimal,
                Value = service.Cost
            });
            SqlConnection.Open();
            SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();

        }
    }
}
