using System;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{   

     class Tree
    {
        node_child[] num =new node_child[2];//자식 배열
        int child_num = 0;
        internal Tree parnet = null;
        string s;
        string str;// 입력
        
        internal void nodeCreat()
        {   if (child_num < 2)
            {
                num[child_num] = new node_child(this);
                Console.WriteLine(child_num+"번 자식 노드가 생성됬습니다");
                child_num++;                
            }
            else
            {
                Console.WriteLine("자식 노드가 모두 생성되어있습니다.");
            }          
        }
        
        internal void input()
        {
            s = null;
            while (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("입력하세요.");
                s = Console.ReadLine();
            }
            Console.WriteLine(s+"가 입력되었습니다.");
        }
        internal void output()
        { if(string.IsNullOrEmpty(s))
            {
                Console.WriteLine ("저장된 값이 없습니다.");
            }
            else
            {
                Console.WriteLine(s+"입니다.");
            }
            
        }

        internal Tree child_search()
        {
            str = null;
            while (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("0번과 1번 중 볼 자식을 선택해주세요");
                str = Console.ReadLine();
            }
            if (!(num[0] == null))// 
            {
                Console.WriteLine(str+"번 노드로 이동했습니다.");
                int numnum = int.Parse(str);
                return num[numnum];
            }
            else if (!(num[1]==null))// 1번 있을 때
            {
                Console.WriteLine(str+"번 노드로 이동했습니다.");
                int numnum = int.Parse(str);
                return num[numnum];
                
            }
            else // 자식 노드가 없을 때 
            {
                Console.WriteLine(str+"번 자식노드가 없습니다.");
                return this;
            }
            
        }
        internal  Tree parnet_search()
        {   if( !(parnet == null)) {
                Console.WriteLine("해당 노드의 부모로 이동했습니다.");
                return  parnet;
            }else 
            {
                Console.WriteLine("최초 노드 입니다.");
                return this;   
            }
        }
    }

    class node_child :Tree
    {        
        internal node_child(Tree tree)
        {
          this.parnet =tree;
        }
        ~node_child()
        {

        }

    }


    class T_Loop
    {
        bool start = false;
        Tree tree;
        string s;
        public T_Loop() { start = true; }

        void init() { tree = new Tree(); }
        void input() {
            s = null;
            while (string.IsNullOrEmpty(s))
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("1을 입력하면 해당 노드에 값을 입력합니다.");
                Console.WriteLine("2을 입력하면 해당 노드에 자식 노드를 만듭니다.");
                Console.WriteLine("3을 입력하면 해당 노드에 입력값을 확인합니다.");
                Console.WriteLine("4을 입력하면 해당 노드의 자식으로 이동합니다.");
                Console.WriteLine("5을 입력하면 해당 노드의 부모로 이동합니다.");
                Console.WriteLine("===============================================");
                s = Console.ReadLine();
            }

            
            
             }
        void Update() {
            switch (s)
            {
                case "1": tree.input();break;
                case "2": tree.nodeCreat();break;
                case "3": tree.output();break;
                case "4": tree=tree.child_search(); break; 
                case "5": tree=tree.parnet_search(); break;
                default: Console.WriteLine("오류"); break;
            }
        
        }
        void Render() { }


        public void Start()
        {

            init();
            while (start)
            {
                input();
                Update();
                Render();
            }

        }

    }

}
