using AGUIRRE_Mongo_SM53.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AGUIRRE_Mongo_SM53.Services
{
    public class bandoServices
    {
        private readonly IMongoCollection<bando> bandoCollection;
        public bandoServices(IOptions<mario_brosDBSettings> mario_brosDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mario_brosDBSettings.Value.Server);
            IMongoDatabase database = mongoClient.GetDatabase(mario_brosDBSettings.Value.Database);
            bandoCollection = database.GetCollection<bando>(mario_brosDBSettings.Value.Collectionbando);
        }
        public async Task<List<bando>> FindAsync() =>
            await bandoCollection.Find(_ => true).ToListAsync();
        //Cambios
        public async Task<bando> FindById(string id) =>
            await bandoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        //Metodo para hacer una actualizacion
        public async Task Insert(bando bandoNew) =>
            await bandoCollection.InsertOneAsync(bandoNew);

        public async Task UpdateOne(string id, bando bandoUpdated) =>
            await bandoCollection.ReplaceOneAsync(x => x.Id == id, bandoUpdated);
        //Eliminar un documento
        public async Task DeleteOne(string id) =>
            await bandoCollection.DeleteOneAsync(x => x.Id == id);
    }
}
