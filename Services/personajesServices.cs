using AGUIRRE_Mongo_SM53.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AGUIRRE_Mongo_SM53.Services
{
    public class personajesServices
    {
        private readonly IMongoCollection<personajes> personajesCollection;
        public personajesServices(IOptions<mario_brosDBSettings> mario_brosDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mario_brosDBSettings.Value.Server);
            IMongoDatabase database = mongoClient.GetDatabase(mario_brosDBSettings.Value.Database);
            personajesCollection = database.GetCollection<personajes>(mario_brosDBSettings.Value.Collectionpersonajes);
        }
        public async Task<List<personajes>> FindAsync() =>
            await personajesCollection.Find(_ => true).ToListAsync();
        //Cambios
        public async Task<personajes> FindById(string id) =>
            await personajesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        //Metodo para hacer una actualizacion
        public async Task Insert(personajes personajesNew) =>
            await personajesCollection.InsertOneAsync(personajesNew);

        public async Task UpdateOne(string id, personajes personajesUpdated) =>
            await personajesCollection.ReplaceOneAsync(x => x.Id == id, personajesUpdated);
        //Eliminar un documento
        public async Task DeleteOne(string id) =>
            await personajesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
