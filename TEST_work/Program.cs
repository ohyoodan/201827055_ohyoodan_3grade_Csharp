int mapsize_row=10;
int mapsize_col=10;


bool a, s, d, f=false;
for (int row = 0; row < mapsize_row; row++)
{


    for (int col = 0; col < mapsize_col; col++)
    {
        a = false;s=false;d=false;f=false;

        if (row==0) {
            
            a = true;
        }
        if(col==0)
        {
            s = true;
        }
        if(col==mapsize_col-1)
        {
            d= true;
        }
        if (row==mapsize_row-1)
        {
            f= true;
        }
        if (a)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if(s){
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (d)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (f)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (s||d)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (f||s)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (a||d)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }else if (d||f)
        {
            Console.ForegroundColor = ConsoleColor.Green;//색상
            Console.Write("●");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;//색상
            Console.Write("●");
        }
        
        

    }
    Console.WriteLine();
}

int[] arr = new int[100];
int currentPos = 0; // 플레이어의 현재 위치
int enemyPos = 6; // 적의 위치

// 각 칸의 정보 초기화
for (int i = 0; i < arr.Length; i++)
{
    // 0: 이동 가능한 빈 칸, 1: 벽, 2: 적, 3: 아군
    if (i == enemyPos)
        arr[i] = 2;
    else if (i == currentPos)
        arr[i] = 3;
    else
        arr[i] = 0;
}

// 이동 가능한 칸인지 확인하는 메소드
bool IsMovable(int pos)
{
    return pos >= 0 && pos < 100 && arr[pos] != 1; // 범위 내에 있고 벽이 아니면 이동 가능
}

// 이동한 위치를 저장하는 배열
int[] visited = new int[100];
int visitedIdx = 0;

// DFS 탐색
void DFS(int pos)
{
    visited[visitedIdx++] = pos;

    // 적을 찾은 경우 탐색 중지
    if (pos == enemyPos)
        return;

    // 상하좌우 이동
    int[] dx = { 0, 0, -1, 1 };
    int[] dy = { -1, 1, 0, 0 };
    for (int i = 0; i < 4; i++)
    {
        int nextPos = pos + dy[i] * 4 + dx[i];
        if (IsMovable(nextPos) && Array.IndexOf(visited, nextPos) == -1) // 이동 가능하고 방문하지 않은 칸인 경우
            DFS(nextPos);
    }
}

// 탐색 시작
DFS(currentPos);

// 이동한 경로 출력
for (int i = 0; i < visitedIdx; i++)
{
    Console.Write(visited[i] + " ");
}