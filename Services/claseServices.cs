using AGUIRRE_Mongo_SM53.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AGUIRRE_Mongo_SM53.Services
{
    public class claseServices
    {
        private readonly IMongoCollection<clase> claseCollection;
        public claseServices(IOptions<mario_brosDBSettings> mario_brosDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mario_brosDBSettings.Value.Server);
            IMongoDatabase database = mongoClient.GetDatabase(mario_brosDBSettings.Value.Database);
            claseCollection = database.GetCollection<clase>(mario_brosDBSettings.Value.Collectionclase);
        }
        public async Task<List<clase>> FindAsync() =>
            await claseCollection.Find(_ => true).ToListAsync();
        //Cambios
        public async Task<clase> FindById(string id) =>
            await claseCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        //Metodo para hacer una actualizacion
        public async Task Insert(clase claseNew) =>
            await claseCollection.InsertOneAsync(claseNew);

        public async Task UpdateOne(string id, clase claseUpdated) =>
            await claseCollection.ReplaceOneAsync(x => x.Id == id, claseUpdated);
        //Eliminar un documento
        public async Task DeleteOne(string id) =>
            await claseCollection.DeleteOneAsync(x => x.Id == id);
    }
}
