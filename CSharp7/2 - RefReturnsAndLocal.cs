using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static c_sharp_7.CSharp7.GiganticData;

namespace c_sharp_7.CSharp7
{
    //Imagine this is a large data structure with many smaller structs.
    //Want to access without repeated allocations
    public class GiganticData
    {
        public PlayerData PlayerData;
        public EnemyData EnemyData;
    }



    public struct PlayerData
    {
        public int Health;
        public int Coins;
        public PlayerInventory Inventory;
        public List<string> Tags;
        public List<PowerUp> Powerups;
        public long AntiCheatHash;
    }

    

    public class RefReturnsAndLocal
    {
        private GiganticData _data;

        public RefReturnsAndLocal()
        {
            _data = new GiganticData();
            _data.PlayerData.Health = 0x00110011;
            _data.EnemyData.Health = 0x00EE00EE;
        }

        public PlayerData GetPlayerDataNoRef()
        {
            //return a copy of the struct
            //ie normal behavior
            return _data.PlayerData;
        }

        public ref PlayerData GetPlayerData()
        {
            //return a ref to an item in an array.
            return ref _data.PlayerData;
        }

        public void TestRefs()
        {

            //EAX contains PTR when done with call (view disassembly)

            //The "ref" here is the 'local' part of "Ref returns and locals"
            //without it, you don't get a reference, but a copy. 
            ref PlayerData dataRef = ref GetPlayerData();

            //also..watch what happens when we use this line instead....
            //ref readonly PlayerData dataRef = ref GetPlayerData();

            //OK, unallowed if we use ref readonly
            dataRef.AntiCheatHash = 9192182181;

            //Example of misuse - COPY not a reference.
            PlayerData dataRef2 =  GetPlayerData();


            dataRef.Health = 10;
            //note disassembly - after call is done EAX contains value
            var dataNoRef = GetPlayerDataNoRef();
        }

        private void TestFindElement()
        {

        }
        //From docs.microsoft.com for a MatrixSearch
        //Returns a REFERENCE to the item that matches the condition.
        public static ref int FindElementInArray(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
            throw new InvalidOperationException("Not found");
        }
    }

    public struct PowerUp
    {

    }
    public struct PlayerInventory
    {

    }
    public struct EnemyData
    {
        public int Health;
    }
}
