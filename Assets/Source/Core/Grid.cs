using System;


namespace Assets.Source.Core
{
    public class Grid<TGridObject>
    {
        public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;

        public class OnGridValueChangedEventArgs : EventArgs
        {
            public int x;
            public int y;
        }

        private int width;
        private int height;

        private TGridObject[,] gridArray;

        public Grid(int width, int height, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
        {
            this.width = width;
            this.height = height;
            gridArray = new TGridObject[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    gridArray[x, y] = createGridObject(this, x, y);
                }
            }
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }
        
        public void SetGridObject(int x, int y, TGridObject value)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                gridArray[x, y] = value;
            }

            if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs {x = x, y = y});
        }

        public TGridObject GetGridObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                return gridArray[x, y];
            }
            else
            {
                return default(TGridObject);
            }
        }

        public void TriggerObjectChange(int x, int y)
        {
            if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }
}
