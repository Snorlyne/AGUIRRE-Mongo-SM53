using AGUIRRE_Mongo_SM53.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AGUIRRE_Mongo_SM53.Services
{
    public class lugaresServices
    {
        private readonly IMongoCollection<lugares> lugaresCollection;
        public lugaresServices(IOptions<mario_brosDBSettings> mario_brosDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mario_brosDBSettings.Value.Server);
            IMongoDatabase database = mongoClient.GetDatabase(mario_brosDBSettings.Value.Database);
            lugaresCollection = database.GetCollection<lugares>(mario_brosDBSettings.Value.Collectionlugares);
        }
        public async Task<List<lugares>> FindAsync() =>
            await lugaresCollection.Find(_ => true).ToListAsync();
        //Cambios
        public async Task<lugares> FindById(string id) =>
            await lugaresCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        //Metodo para hacer una actualizacion
        public async Task Insert(lugares lugaresNew) =>
            await lugaresCollection.InsertOneAsync(lugaresNew);

        public async Task UpdateOne(string id, lugares lugaresUpdated) =>
            await lugaresCollection.ReplaceOneAsync(x => x.Id == id, lugaresUpdated);
        //Eliminar un documento
        public async Task DeleteOne(string id) =>
            await lugaresCollection.DeleteOneAsync(x => x.Id == id);
    }
}
