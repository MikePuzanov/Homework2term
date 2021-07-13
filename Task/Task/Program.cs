using System;
using System.Collections;
using System.Collections.Generic;

namespace HwProjTask
{
    class Entity1
    {
        public int EntityId { get; set; }
        public string Data { get; set; }
        public DateTime CreationTime { get; set; }
        public int? Entity2Id { get; set; }
        public bool Flag { get; set; }

        public Entity1(int id, string data, DateTime time, int? id2, bool flag)
        {
            EntityId = id;
            Data = data;
            CreationTime = time;
            Entity2Id = id2;
            Flag = flag;
        }
    }

    class Entity2
    {
        public int EntityId { get; set; }
        public double Data { get; set; }
        public DateTime CreationDate { get; set; }

        public Entity2(int id, double data, DateTime time)
        {
            EntityId = id;
            Data = data;
            CreationDate = time;
        }
    }

    class EntityAggregate
    {
        public int EntityId { get; set; }
        public string Data { get; set; }
        public DateTime CreationTime { get; set; }
        public bool Flag { get; set; }

        public Entity2 E2;
        public EntityAggregate(Entity1 e1, Entity2 e2)
        {
            EntityId = e1.EntityId;
            Data = e1.Data;
            CreationTime = e1.CreationTime;
            Flag = e1.Flag;
            E2 = e2;
        }
    }

    class Program
    {
        /// Задача:
        /// Даны два массива сущностей,
        /// Сущности из первого массива содержат идентификаторы сущностей из второго массива,
        /// Реализовать Join, обьединяющий данные сущностей из двух массивов,
        /// Вернуть массив EntityAggregate, содержащий обьединённые данные,
        /// предварительно отфильтровав сущности из первого массива по entity.Flag == hasFlag
        ///
        /// Пример работы:
        ///
        /// Входные данные:
        /// e1 = Entity1(EntityId = 1,
        ///              Data = "123",
        ///              Flag = false,
        ///              Entity2Id = 2,
        ///              CreationDate = 29.10.1999)
        ///
        /// e2 = Entity2(EntityId = 2,
        ///              Data = 2.4,
        ///              CreationDate = 30.10.1999)
        ///
        /// hasFlag = false
        ///
        /// Возвращаемое значение:
        /// EntityAggregate(EntityId = 1,
        ///                 Data = "123",
        ///                 Flag = false,
        ///                 CreationDate = 29.10.1999,
        ///                 Entity2 = Entity2(EntityId = 2,
        ///                                   Data = 2.4,
        ///                                   CreationDate = 30.10.1999)

        static EntityAggregate[] Join(Entity1[] e1, Entity2[] e2, bool hasFlag)
        {
            var entityQueue = new Queue<EntityAggregate>();
            for (int i = 0; i < e1.Length; i++)
            {
                if (e1[i].Flag == hasFlag)
                {
                    if (e1[i].Entity2Id == null)
                    {
                        entityQueue.Enqueue(new EntityAggregate(e1[i], null));
                    }
                    else
                    {
                        for (int j = 0; j < e2.Length; j++)
                        {
                            if (e1[i].Entity2Id == e2[j].EntityId)
                            {
                                entityQueue.Enqueue(new EntityAggregate(e1[i], e2[j]));
                            }
                        }
                    }
                }
            }
            return entityQueue.ToArray();
        }
    }
}