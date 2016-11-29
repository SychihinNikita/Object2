﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebUI.DAL.Entities;
using WebUI.DAL.EF;
using WebUI.DAL.Interfaces;
namespace WebUI.DAL.Repositories
{
 public class OrderRepository :IRepository<Order>
    {
        private MobileContext db;

        public OrderRepository(MobileContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.Phone);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.Phone).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
