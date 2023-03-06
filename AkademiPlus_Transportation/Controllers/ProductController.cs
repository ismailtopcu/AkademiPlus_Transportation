﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkademiPlus_Transportation.Models;

namespace AkademiPlus_Transportation.Controllers
{
    public class ProductController : Controller
    {
        DbTransportEntities db = new DbTransportEntities();
        public ActionResult Index()
        {
            var values = db.TblProduct.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(TblProduct tblProduct)
        {
            db.TblProduct.Add(tblProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = db.TblProduct.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateProduct(TblProduct tblProduct)
        {
            var value = db.TblProduct.Find(tblProduct.ProductID);
            value.ProductName = tblProduct.ProductName;
            value.ProductSize = tblProduct.ProductSize;
            value.ProductSizeType = tblProduct.ProductSizeType;
            value.ProductDescription = tblProduct.ProductDescription;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = db.TblProduct.Find(id);
            db.TblProduct.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}