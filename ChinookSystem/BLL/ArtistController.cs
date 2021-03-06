﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel;
using ChinookSystem.DAL;
using ChinookSystem.VIEWMODELS;
using ChinookSystem.ENTITIES;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        #region Queries
        //Due to the fact that the entities will be internal
        //you will NOT be able to use them directly as return datatypes.
        //Instead, we will create viewmodel classes that will contain the data definition
        //for your return data type.
        //To fill these view classes we will use a simple Linq query.
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistViewModel> Artist_List()
        {
            using (var context = new ChinookSystemContext())
            {
                //linq query
                //linq queries are returned as IEnumerable or IQueryable datasets
                //you can use var when declaring your query receiving variable
                var results = from x in context.Artists
                              select new ArtistViewModel
                              {
                                  ArtistId = x.ArtistId,
                                  ArtistName = x.Name,
                                  NameAndId = x.Name + " ( " + x.ArtistId + " )"
                              };
                return results.OrderBy(x => x.ArtistName).ToList();
            }
        }
        #endregion  
    }
}
