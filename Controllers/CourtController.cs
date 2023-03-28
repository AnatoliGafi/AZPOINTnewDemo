using CourtWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourtWebAPI.Controllers
{
    public class CourtController : ApiController
    {

        [HttpGet]
        [System.Web.Http.Route("api/Court/GetNewCase/")]
        public Case GetNewCase()
        {
            return new Case();
        }
        [HttpPost]
        [System.Web.Http.Route("api/Court/SaveNewCase/")]
        public Case SaveNewCase(Case newcase)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
               
                try
                {
                    newcase.IssModDateTime = DateTime.Now;
                    entities.Cases.Add(newcase);
                    entities.SaveChanges();
                    newcase.CaseUID = newcase.ID;
                    return newcase;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                    throw;
                }


            }
        }
        [HttpPost]
        [System.Web.Http.Route("api/Court/UpdateCase/")]
        public void UpdateCase(Case newcase)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                newcase.IssModDateTime = DateTime.Now;
                entities.Cases.Attach(newcase);
                entities.Entry(newcase).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
            }
        }
        //======================================================================================ORDERS
        [HttpGet]
        [System.Web.Http.Route("api/Court/GetNewOrder/")]
        public Order GetNewOrder()
        {
            return new Order();
        }
        [HttpPost]
        [System.Web.Http.Route("api/Court/SaveNewOrder/")]
        public Order SaveNewOrder(Order order)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {

                try
                {
                    order.IssModDateTime = DateTime.Now;
                    entities.Orders.Add(order);
                    entities.SaveChanges();
                    order.OrderUID = order.ID;
                    return order;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                    throw;
                }


            }
        }

        [HttpPost]
        [System.Web.Http.Route("api/Court/UpdateOrder/")]
        public void UpdateOrder(Order order)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                order.IssModDateTime = DateTime.Now;
                entities.Orders.Attach(order);
                entities.Entry(order).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
            }
        }



    }
}
