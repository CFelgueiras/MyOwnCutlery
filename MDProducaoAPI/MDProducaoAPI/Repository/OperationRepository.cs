using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MDProducaoAPI.Models;
using MDProducaoAPI.Repository.Interfaces;
using System.Net.Http.Headers;
using System;
using System.Net.Http;
using MDProducaoAPI.Models.MVDTO;
using MDProducaoAPI.MVDTO;
using Newtonsoft.Json;

namespace MDProducaoAPI.Repository
{
    public class OperationRepository : Repository<Operation>, IOperationRepository
    {
        private readonly Context _context;

        public OperationRepository()
        {
        }

        public MVOperation GetOperationByID(long id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://mdf3nbgrp5.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string operById = "api/operation/" + id.ToString();
            HttpResponseMessage response = client.GetAsync(operById).Result;

            MVOperation operation = new MVOperation();
            if (response.IsSuccessStatusCode)
            {
                operation = JsonConvert.DeserializeObject<MVOperation>(response.Content.ReadAsStringAsync().Result);
            }

            return operation;
        }
        
        public MVOperationTool GetOperationsFromMDFByOperationTool(string opTool)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://mdf3nbgrp5.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string OpToolURL = "api/operation/operationtool/" + opTool;
            HttpResponseMessage response = client.GetAsync(OpToolURL).Result;

            MVOperationTool operation = new MVOperationTool();
            if (response.IsSuccessStatusCode)
            {
                operation = JsonConvert.DeserializeObject<MVOperationTool>(response.Content.ReadAsStringAsync().Result);
            }

            return operation;
        }

        public OperationRepository(Context dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public Operation GetById(long id)
        {
            return _context.Operations.Find(id);
        }

        public List<Operation> GetByName(string name)
        {
            return _context.Operations
                .Include(o => o.Name)
                .Where(n => n.Name.name.Equals(name))
                .ToList();
        }

        public List<Operation> GetByOperationTool(string operationTool)
        {
            return _context.Operations
                .Include(o => o.OperationTool)
                .Where(x => x.OperationTool.operationTool.Equals(operationTool))
                .ToList();
        }

        public Operation Create(Operation operation)
        {
            _context.Operations.Add(operation);
            _context.SaveChanges();
            return operation;
        }

        public List<Operation> GetOperationsByManPlanId(long manPlanID)
        {
            return _context.Operations
                .Include(m => m.ManufacturingPlan)
                .Where(mp => mp.ManufacturingPlan.manufacturingPlanId == manPlanID)
                .ToList();
        }


    }
}