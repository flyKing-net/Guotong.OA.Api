using Guotong.Api.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public class DbContext<T> where T : class, new()
{
    public static string ConnectionString { get; set; }

    public DbContext() {
        ConnectionString = BaseDBConfig.ConnectionString;  
    }

    public IDbConnection Connection {
        get {
            return new SqlConnection(ConnectionString);
        }
    }


    public void Add() { 
    
    }
}

