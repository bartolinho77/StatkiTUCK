
namespace StatkiTUCK
{
        class Ship
        {
        private readonly int StartCoordX;
        private readonly int StartCoordY;
        private bool[] StateOfFlagpoles;
        private readonly bool IsVertical;

        public Ship(int NumberOfFlagpoles, int StartPosX, int StartPosY, bool Vertical)
            {
                StartCoordX = StartPosX;
                StartCoordY = StartPosY;

                StateOfFlagpoles = new bool[NumberOfFlagpoles];

                for (int i = 0; i < NumberOfFlagpoles; i++)
                {
                    StateOfFlagpoles[i] = true; //is alive
                }

                IsVertical = Vertical;
            }



            public bool CheckOrHitIt(int HitX, int HitY, bool checkIfExistsOnly = false)
            {
                if (IsVertical && HitX == StartCoordX)
                {
                    if (0 <= (HitY - StartCoordY) && (HitY - StartCoordY) < StateOfFlagpoles.Length)
                    {
                        if (!checkIfExistsOnly)
                            StateOfFlagpoles[HitY - StartCoordY] = false;
                        return true;
                    }

                }
                else if (!IsVertical && HitY == StartCoordY)
                {
                    if (0 <= (HitX - StartCoordX) && (HitX - StartCoordX) < StateOfFlagpoles.Length)
                    {
                        if (!checkIfExistsOnly)
                            StateOfFlagpoles[HitX - StartCoordX] = false;
                        return true;
                    }
                }

                return false;
            }




            public bool HasBeenDestroyed()
            {
                for (int i = 0; i < StateOfFlagpoles.Length; i++)
                {
                    if (StateOfFlagpoles[i]) return false;
                }
                return true;
            }
        }

}
