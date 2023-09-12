using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.ConfigDetailsfolder
{
    public class ConfigDetailsRepository : IConfigDetailsRepository
    {
        private readonly AppDbContext context;

        public ConfigDetailsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ConfigDetails> AddConfigDetails(ConfigDetails configDetails)
        {
            context.Config_Details.Add(configDetails);
            await context.SaveChangesAsync();
            return configDetails;
        }

        public async Task<ConfigDetails?> DeleteConfigDetails(int configDetailsId)
        {
            ConfigDetails configDetails = await context.Config_Details.FindAsync(configDetailsId);
            if (configDetails != null)
            {
                context.Config_Details.Remove(configDetails);
                await context.SaveChangesAsync();
            }
            return configDetails;
        }

        public async Task<ConfigDetails> GetConfigDetailsById(int configDetailsId)
        {
            var configDetails = await context.Config_Details.FindAsync(configDetailsId);
            return configDetails;
        }

        public async Task<ConfigDetails?> UpdateConfigDetails(int configDetailsId, ConfigDetails updatedConfigDetails)
        {
            if (configDetailsId != updatedConfigDetails.Config_DetailsID)
            {
                return null;
            }

            context.Entry(updatedConfigDetails).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigDetailsExists(configDetailsId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return updatedConfigDetails;
        }

        private bool ConfigDetailsExists(int configDetailsId)
        {
            return context.Config_Details.Any(e => e.Config_DetailsID == configDetailsId);
        }
    }
}
