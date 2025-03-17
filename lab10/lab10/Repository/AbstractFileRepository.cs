namespace lab10.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public abstract class AbstractFileRepository<ID, E> : InMemoryRepository<ID, E> where E : class, IEntity<ID>
    {
        private readonly string _fileName;

        public AbstractFileRepository(string fileName) 
        {
            _fileName = fileName;
            LoadData();
        }

        private void LoadData()
        {
            if (!File.Exists(_fileName))
                return;

            try
            {
                using StreamReader reader = new StreamReader(_fileName);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    List<string> data = line.Split(',').ToList();
                    E entity = ExtractEntity(data);
                    base.Save(entity);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Eroare la citirea fișierului: " + e.Message);
            }
        }

        public abstract E ExtractEntity(List<string> attributes);
        protected abstract string CreateEntityAsString(E entity);

        public override E Save(E entity)
        {
            E result = base.Save(entity);
            if (result == null)
            {
                WriteToFile(entity);
            }
            return result;
        }

        private void WriteToFile(E entity)
        {
            try
            {
                using StreamWriter writer = new StreamWriter(_fileName, append: true);
                writer.WriteLine(CreateEntityAsString(entity));
            }
            catch (IOException e)
            {
                Console.WriteLine("Eroare la scrierea în fișier: " + e.Message);
            }
        }
    }
}