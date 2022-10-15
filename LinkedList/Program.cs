
//pointer
//unsafe
//{
//int r = 5;
//int*g = &r;
//    Console.WriteLine((int)g);
//    Console.WriteLine(*g);
//    char*p1,p2;
//}

using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;


namespace app
{

    class program {

    //-----------------------------------------------------------//
        static void Main()
        {
            linkedList list2 = new linkedList();




            list2.insert_end(32333);

            Console.WriteLine(list2.Max());

            list2.debug_verify_data_integrity();


        }

    }
    class node
    {
        public int value;
        public node next;
        public node(int value )
        {
            this.value = value;
            
        }

    }


    //--------------------------------------------------------//
    class linkedList
    {
        public node head = null;
        public node tail = null;
        public int length=0;
        //medium problems


        public int Max(node cur = null,int max=int.MinValue,int c=1)
        {
            if(c==1) cur = head;

            if (length == 0)
            {
                Console.Write("the list is empty ");
                return max;
            }
            else
            {

                if (cur.next == null)
                {
                    if (cur.value >= max) max = cur.value;
                    Console.Write("max value is : ");
                    return max;
                }
                else if (cur.value >= max) max= cur.value;

                return Max(cur.next,max,++c);
            }
        }
        public bool delete_by_value(int val)
        {
            if (head.value == val)
            {
                delete_first();
                return true;
            }
            if (tail.value == val)
            {
                deleteLastNode();
                return true;
            }

            for(node cur = head; cur.next != null; cur = cur.next)
            {
                if (cur.next.value == val)
                {
                    node temp = cur.next.next;
                    cur.next.next = null;
                    cur.next = temp;
                    length--;
                    return true; 
                }
            }
            return false;
        }

        public void Move_To_Back(int key)
        {
            int counter = 0;
            
            bool cas = delete_by_value(key);
            while (cas)
            {
                counter++;
                cas= delete_by_value(key);  
            }

            for (int i = 0; i <counter; i++)
            {
                insert_end(key);
            }
        }

        public void Swap_head_and_tail()
        {
            if (length == 1)
            {
                Console.WriteLine("list has only one item");
                return;
            }
            else if(length == 2)
            {
                head.next = null;
                node Hcopy = head;
                head = tail;
                tail = Hcopy;
                head.next = tail;
                return;
            }
            else
            {
                node prev = null;
                node Hnext = head.next;
                for(node cur = head; cur != null; cur = cur.next)
                {
                    if (cur.next.next == null)
                    {
                        prev = cur;
                        break;
                    }
                }
                head.next = null;
                prev.next = head;
                tail.next = Hnext;

                node hcopy = head;
                head = tail;
                tail = hcopy;

            }
        }
        
        public void Left_Rotate(int k)
        {

            if (k % length == 0) return;
            if (k > length) k = k % length;

            int counter = 1;
            node last = null;
            for(node cur=head;cur!=null;cur = cur.next)
            {
                if (counter == k)
                {
                    last = cur;
                }
                ++counter;
            }

            node newhead=last.next;
            last.next = null;
            tail.next = head;
            head = newhead;
            tail = last;
        }


        public void Remove_Duplicates()
        {
            //search for every
            for(node cur = head; cur != null; cur = cur.next)
            {
                string indx = "";
                int counter = 1;
                for(node cur2 = head; cur2 != null; cur2 = cur2.next)
                {
                    if (cur.value == cur2.value)
                    {
                        indx += counter;
                    }
                        counter++;
                }
                int corrector = 0;
                for(int i = 1; i < indx.Length; i++)
                {
                    deleteNthNOde(indx[i]-corrector-48);
                    corrector++;
                }
            }
        }

        public void remove_last_occurance(int key)
        {
            string indx = "";
            int counter = 1;
                for (node cur2 = head; cur2 != null; cur2 = cur2.next)
                {
                    if (cur2.value ==key)
                    {
                        indx += counter;
                    }
                    counter++;
                }
            if (indx.Length == 0 ) return;
            deleteNthNOde(indx[indx.Length-1]-48);
                    
                
            
        }


        //easy problems
        public void reverse()
        {
            if (length <= 1) return;
            tail = head;
            node pre = head;
            head = head.next;
            while(head != null)
            {
                node next = head.next;
                head.next = pre;
                
                pre=head;
                head=next;
            }
            head=pre;
            tail.next = null;
    
        }


        public void insert_sorted(int num)
        {
            if (head==null||head.value>=num)
            {
                insert_front(num);

                return;
            }
            for(node cur = head,pre=null; cur != null; cur = cur.next)
            {
                if (num <= cur.value)
                {
                    node newnode=new node(num);
                    pre.next = newnode;
                    newnode.next=cur;
                    length++;
                    return;
                }
                pre = cur;
            }
            insert_end(num);

        }
        public void delete_even_positions()
        {
            deleteNthNOde(2);
            for(int i = 3; i <=length; i++)
            {

                deleteNthNOde(i);


            }
        }
        public void swap_each_pair_values()
        {
            for(int i = 1; i < length; i += 2)
            {
                node node1 = GetNth(i);
                node node2=GetNth(i+1);
                int temp = node1.value;
                node1.value = node2.value;
                node2.value= temp;
            }
        }


        public void delete_with_key(int key)
        {
            if (length == 0)
            {
                Console.WriteLine("the list is empty\n");
                return;
            }
            if (head.value == key) delete_first();
            
            for(node cur=head,pre=head ; cur!=null; cur=cur.next)
            {
                if (cur.value == key)
                {
                    var temp = cur.next;
                    cur.next = null;
                    pre.next = temp;
                    length--;
                    return;
                }
                
                pre=cur;
            }
            Console.WriteLine("this key is not in the list \n");
        }

        public void insert_end(int val)
        {
            if (head==null)
            {
                head = tail = new node(val);
            }
            else
            {
                node newnode = new node(val);
                tail.next = newnode;
                newnode.next = null;
                tail = newnode;
                
            }
            length++;
        }
        public void insert_front(int val)
        {
            node newnode=new node(val);
            newnode.next = head;
            head = newnode;
            length++;
            if (length == 1) tail = head;
            
        }

        public void delete_front()
        {
            head = head.next;
            length--;
            
        }
        public node GetNthfromBack(int n)
        {
            if (n == 1)return tail;
            if(n==length)return head;

            int pos = length - n + 1;
            node cur = head;
            int idx = 0;
            while(cur != null)
            {
                if (++idx == pos) return cur;
                cur = cur.next;
            }
            return null;
        }
        public void print()
        {
            
            for(node cur=head;cur!=null; cur = cur.next)
            {
                Console.Write(cur.value+" ");

            }
            Console.Write("\n");
        }

        public node GetNth(int n)
        {
            if (n<=0||n > length) return null;
            node cur = head;
            for(int i=1;i<n;i++)
            {
                cur=cur.next;

            }
            return cur;
        }
        public bool isSame(ref linkedList  l)
        {
            if(length==l.length)
            {

            var cur1 = l.head;
            var cur2 = head;
                int count = 0;
                while (cur1!= null)
                {
                    if (cur1.value != cur2.value)
                        return false;
                        
                    cur1=cur1.next;
                    cur2=cur2.next;

                }
                return true;

      
           
            }
            else
            {
                return false;
            }
            

        }

        public int search(int val)
        {
            int idx = 0;
            for(node cur = head; cur != null; cur = cur.next)
            {
                if (cur.value == val) return idx;
                idx++;
            }
            return -1;
        }        
        public int search_improve(int val)
        {
            int idx = 0;
            if(head.value == val) return idx;
            for (node cur = head, pre = null; cur != null; pre = cur, cur = cur.next)
            {
                if (cur.value == val) {
                    int temp = cur.value;
                    cur.value = pre.value;
                    pre.value = temp;
                    return idx-1;
                }
                idx++;
                
            }
            return -1;
        }

        public void delete_first()
        {
            if(length!=0)
            {
                node temp = head;
                head = head.next;
                temp.next = null;
            length--;
            }
            else
            {
                Console.Write("the list is empty");
            }
        }

        public void deleteLastNode()
        {
            if (length <= 1)
            {
                delete_first();
                return;
            }
            else if (length >1)
            {
                var cur = head;
                while (cur!=null){
                    if (cur.next.next == null)
                    {
                        cur.next = null;
                        tail = cur;
                        length--;
                        return;
                    }
                    cur= cur.next;
                }
            }

        }

        public void deleteNthNOde(int num)
        {
            if (num < 1 || num > length)
            {
                Console.WriteLine("eror , No such nth node\n");
            }
            else if (num == 1)
            {
                delete_first();
                return;
            }
            else if (num == length)
            {
                deleteLastNode();
                return;
            }
            else { 
                node cur = head;
                for(int i=1;i<num-1; i++)
                {
                    cur = cur.next;

                }
                node prev = cur;

                node temp= prev.next.next;
                prev.next.next = null;
                prev.next=temp;
                length--;
            }
        }





        public void debug_verify_data_integrity()
        {
            if (length == 0)
            {
                Debug.Assert(head==null);
                Debug.Assert(tail==null);

            }
            else
            {
                Debug.Assert(head !=null);
                Debug.Assert(tail!=null);
                if (length == 1)
                    Debug.Assert(head == tail);
                else
                    Debug.Assert(head != tail);
                //Debug.Assert(tail == null);

            }
            int len = 0;
            for(node cur = head; cur !=null; cur = cur.next, ++len)
            {
                Debug.Assert(len < 10000);//consider infinite cycle

            }
            Debug.Assert(length== len);
            

        }

        public string debug_to_string()
        {
            if (length == 0)
            {
                return "";
            }
            string str = "";
            for (node cur = head; cur!=null; cur = cur.next)
            {
                str+=Convert.ToString(cur.value);
                if (cur.next!=null)
                {
                    str += " ";
                }
            }
            return str;
        }
         
    }












    //------------------------------------------------------------------------//
    class linkedListOnlyHead
    {
        public node head = null;

        public void print()
        {
            node cur = head;
            while (cur != null)
            {
                Console.Write(cur.value + " ");
                cur = cur.next;
            }
        }

        public void add(int val)
        {


            node newnode = new node(val);
            newnode.next = head;
            head = newnode;

        }
    }


    class funcutions
    {

    //--------------------------------------------------------------//
        static void printRecursive(node cur2)
        {

            if (cur2 == null)
            {
                Console.Write("null");
                return;
            }


            Console.Write(cur2.value + "->");
            printRecursive(cur2.next);
        }
        static void printRecursiveReversed(node cur2)
        {

            if (cur2 == null)
            {
                Console.Write("null->");
                return;
            }


            printRecursiveReversed(cur2.next);
            Console.Write(cur2.value + "->");
        }
        static node search(node head, int val)
        {
            while (head.next != null)
            {
                if (head.value == val) return head;
                else head = head.next;
            }
            return null;
        }
    }



}