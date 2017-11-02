using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BookingLibrary.Service.Repository.Domain;
using BookingLibrary.Service.Repository.Domain.ViewModels;

namespace BookingLibrary.Infrastructure.DataPersistence.Repository.SQLServer.Extensions
{
    public static class ConvertExtension
    {
        public static BookViewModel ConvertToBookViewModel(this DataRow dr) 
        {
            if (dr == null)
            {
                return null;
            }
            else
            {
                var model = new BookViewModel();

                model.BookId = Guid.Parse(dr["BookId"].ToString());
                model.BookName = dr["BookName"].ToString();
                model.DateIssued = Convert.ToDateTime(dr["DateIssued"]);
                model.ISBN = dr["ISBN"].ToString();
                model.Description = dr["Description"].ToString();

                return model;
            }
        }

        public static BookDetailedModel ConvertToBookDetailedModel(this DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            else
            {
                var model = new BookDetailedModel();

                model.BookId = Guid.Parse(dr["BookId"].ToString());
                model.BookName = dr["BookName"].ToString();
                model.DateIssued = Convert.ToDateTime(dr["DateIssued"]);
                model.ISBN = dr["ISBN"].ToString();
                model.Description = dr["Description"].ToString();

                return model;
            }
        }

        public static List<BookViewModel> ConvertToBookViewModel(this DataTable dt)
        {
            return dt.Rows.Cast<DataRow>().Select(ConvertToBookViewModel).ToList();
        }

        public static List<BookDetailedModel> ConvertToBookDetailedModel(this DataTable dt)
        {
            return dt.Rows.Cast<DataRow>().Select(ConvertToBookDetailedModel).ToList();
        }
    }
}