using AGUIRRE_Mongo_SM53.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AGUIRRE_Mongo_SM53.Services
{
    public class poderesServices
    {
        private readonly IMongoCollection<poderes> poderesCollection;
        public poderesServices(IOptions<mario_brosDBSettings> mario_brosDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mario_brosDBSettings.Value.Server);
            IMongoDatabase database = mongoClient.GetDatabase(mario_brosDBSettings.Value.Database);
            poderesCollection = database.GetCollection<poderes>(mario_brosDBSettings.Value.Collectionpoderes);
        }
        public async Task<List<poderes>> FindAsync() =>
            await poderesCollection.Find(_ => true).ToListAsync();
        //Cambios
        public async Task<poderes> FindById(string id) =>
            await poderesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        //Metodo para hacer una actualizacion
        public async Task Insert(poderes poderesNew) =>
            await poderesCollection.InsertOneAsync(poderesNew);

        public async Task UpdateOne(string id, poderes poderesUpdated) =>
            await poderesCollection.ReplaceOneAsync(x => x.Id == id, poderesUpdated);
        //Eliminar un documento
        public async Task DeleteOne(string id) =>
            await poderesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
