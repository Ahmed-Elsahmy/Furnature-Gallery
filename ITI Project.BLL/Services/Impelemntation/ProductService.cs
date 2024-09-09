﻿using AutoMapper;
using ITI_Project.BLL.Helper;
using ITI_Project.BLL.ModelVM;
using ITI_Project.BLL.Services.Interface;
using ITI_Project.DAL.Entites;
using ITI_Project.DAL.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Project.BLL.Services.Impelemntation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo ProductRepo;
        private readonly IMapper mapper;

        public ProductService(IProductRepo ProductRepo, IMapper mapper)
        {
            this.ProductRepo = ProductRepo;
            this.mapper = mapper;
        }

        public bool Create(CreateProductVM product)
        {
            try
            {
                product.Image = UploadImg.UploadFile("Profile", product.ImageName);
                Product new_product = mapper.Map<Product>(product);

                ProductRepo.Create(new_product);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                ProductRepo.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetProductVM> GetAll()
        {
            var result = ProductRepo.GetAll().Where(a => a.IsDeleted == false).ToList();
            List<GetProductVM> newResult = mapper.Map<List<GetProductVM>>(result);
            return newResult;
        }

        public GetProductVM GetByProductId(int id)
        {
            Product product = ProductRepo.GetByProductId(id);
            return mapper.Map<GetProductVM>(product);
        }

        public bool Update(UpdateProductVM product)
        {
            try
            {
                Product new_product = mapper.Map<Product>(product);
                UploadImg.RemoveFile("Profile", new_product.image);
                new_product.image = UploadImg.UploadFile("Profile", product.ImageName);
                ProductRepo.Update(new_product);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
