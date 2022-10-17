using System.Globalization;

namespace DoublyLinkedList
{
    class program
    {
        static void Main()
        {
            Doubly_linked_list dl = new Doubly_linked_list();
            dl.insert_end(1);
            dl.insert_front(0);
            dl.insert_front(2);
            dl.print();
        }
    }


    class node
    {
        public int Data;
        public node next ;
        public node prev;



        public node(int Data)
        {
             this.Data = Data; 
        }
    }

    class Doubly_linked_list
    {
        public node head=null;
        public node tail=null;
        public int lenght = 0;

        void link(node first,node second)
        {
            if(first!=null)
            first.next = second;
            if(second!=null)
            second.prev = first;
        }
        public void insert_front(int value)
        {
            node item = new node(value);
            if (head == null)
            {
                head = tail = item;
            }
            link(item, head);
            head = item;
        }
        public void insert_end(int value)
        {
            node item= new node(value);
            if (head == null) { head=tail=item; }
            else
            {
                link(tail, item);
                tail = item; 
            }

        }

        public void print()
        {
            for(node cur = head; cur != null; cur = cur.next)
            {
                Console.Write(cur.Data + " ");
            }
        }
    }

}