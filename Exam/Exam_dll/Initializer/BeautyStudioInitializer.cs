﻿using Exam_dll.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_dll.Initializer
{
    public class BeautyStudioInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var users = new List<UserData>()
            {
                new UserData()
                {
                     Name = "Iryna",
                     LastName = "Mertsalova",
                     BirthDate = new DateTime(2004, 03, 10),
                     Image= "https://www.instagram.com/p/CACqhIpAQ7X/?utm_source=ig_web_copy_link"
                },
                new  UserData()
                {
                    Name="Kate",
                    LastName="Androsiuk",
                    BirthDate = new DateTime(2004, 03, 10),
                    Image = "data:image/png;base64,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"
                }
            };

            var specialities = new List<Speciality>()
            {
                new Speciality(){ Name = "Brow master" },
                new Speciality(){ Name = "Hair master" },
                new Speciality(){ Name = "Nails master" },
                new Speciality(){ Name = "Facial master" },
                new Speciality(){ Name = "Massage master" }
            };

            var serviceTypes = new List<ServiceType>()
            {
                new ServiceType(){Name="Brow"},
                new ServiceType(){Name="Hair"},
                new ServiceType(){Name="Nails"},
                new ServiceType(){Name="Face"},
                new ServiceType(){Name="Massage"}
            };

            var beautyServices = new List<BeautyService>()
            {
                new BeautyService()
                {
                    Name = "Eyebrow Coloring And Correction",
                    Price = 200,
                    ServiceType = serviceTypes.FirstOrDefault(x=>x.Name == "Brow")
                },
                new BeautyService()
                {
                    Name = "Model hairstyles",
                    Price = 150,
                    ServiceType = serviceTypes.FirstOrDefault(x=>x.Name == "Hair")
                },
                new BeautyService()
                {
                  Name = "Manicure",
                  Price = 250,
                   ServiceType = serviceTypes.FirstOrDefault(x=>x.Name == "Nails")
                },
                new BeautyService()
                {
                    Name = "Facial Cleansing",
                    Price = 350,
                    ServiceType = serviceTypes.FirstOrDefault(x=>x.Name == "Face")
                },
                new BeautyService()
                {
                    Name = "Hot stone massage",
                    Price = 500,
                    ServiceType = serviceTypes.FirstOrDefault(x=>x.Name == "Massage")
                }
            };

            context.Users.Add() 
            base.Seed(context);
        }
    }
}
