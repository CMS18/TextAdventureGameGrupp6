namespace TextAdventure
{
    public class Item
    {
        public string ID;
        public string name;
        public bool pickUpAble;
        public string playerInventoryDesc;
        public string roomInventoryDesc;

        public Item(string itemName, string playerInvDesc, string roomInvDesc, string itemID, bool small)
        {
            name = itemName;
            playerInventoryDesc = playerInvDesc;
            roomInventoryDesc = roomInvDesc;
            ID = itemID;
            pickUpAble = small;
        }
    }
}