using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BookLibrary.Service.Inventory.Domain;
using BookLibrary.Service.Inventory.Domain.ViewModels;

namespace BookLibrary.Infrastructure.DataPersistence.Inventory.SQLServer.Extensions
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

        public static BookInventoryViewModel ConvertToBookInventoryViewModel(this DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            else
            {
                var model = new BookInventoryViewModel();

                model.BookInventoryId = Guid.Parse(dr["BookInventoryId"].ToString());
                model.LastNote = dr["LastNote"].ToString();
                model.Status = (BookInventoryStatus)Enum.Parse(typeof(BookInventoryStatus), dr["Status"].ToString());

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

        public static List<BookInventoryViewModel> ConvertToBookInventoryViewModel(this DataTable dt)
        {
            return dt.Rows.Cast<DataRow>().Select(ConvertToBookInventoryViewModel).ToList();
        }
    }
}