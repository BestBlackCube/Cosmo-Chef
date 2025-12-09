# Cosmos-Chef 클라이언트 개발 1.1.0v
## 기능 설명
게임의 스토리를 보기 위해서는 플레이어는 퍼즐을 풀어야 하는 요소가 존재한다.  

게임의 시작은 동영상을 보는 것처럼 캐릭터가 자동으로 움직이며, 특정 구간에 도달 했을때 TMPro를 사용하여
게임의  
스토리를 텍스트와 Image를 사용하여 보여준다. 하지만 게임이 그저 동영상처럼 전부 자동으로 되어 있다면 이 게임을  
하는 플레이어들이 왜 이것이 게임이 모르기에, 중간에 퍼즐 요소를 추가하여 다음 스토리를 볼 수 있는 구조를 만든다.

- ## 플레이어
   - ### [Player_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/Player/Player_Script.cs)
      - 플레이어가 직접 조작하는 move, jump, hit등 제어하는 기능과 자동이동 기능이 들어있다.  
      
         스토리 진행일땐 [AutoMove](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/Player/Player_Script.cs#L141-L160) 기능이 켜져있어 플레이어가 움직이려고 해도 움직여 지지 않는다.  
         자동 움직임일때, 오른쪽으로 이동과 JumpPad 오브젝트의 BoxCollider와 만나면 점프하는 구조이다.
   - ### [JumpPad.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/JumpPad/JumpPad.cs)
      - 스토리 진행일때 플레이어의 자동 이동 기능이 켜져 있는 상태로 해당 오브젝트의 BoxCollider와 충돌이  
      일어나게 되면 플레이어 캐릭터는 점프를, 점프패드 오브젝트는 내부 카운트를 통해 switch(Count)에서  
      다음 위치로 이동 하게 된다.  

         각각의 위치에 점프 패드 오브젝트를 설치 하면 되긴 하지만, 용량을 최소화를 시키기 위해 하나의  
         오브젝트를 이동시키는 구조로 제작하였다.
   - ### [Food_Script](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/Food_Script.cs)
      - 플레이어가 식재료 또는 아이템을 먹게 되면 FoodTroy_Script에 있는 카운트가 오른다.

   - ### [FoodTory_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/Player/FoodTory_Script.cs)
      - 스토리가 진행되면서 식재료 또는, 아이템의 카운트 시스템을 관리 하는 기능이며,  
        현재는 개발 단계이다.
   - ### 씬 버튼
      - [Start_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/Start_Script.cs) 메인 화면에서 게임 씬으로 넘어갈 수 있는 버튼이다.  
      - [mainMenu_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/mainMenu_Script.cs) 메인 화면으로 넘어가는 버튼이다.
      - [Retry_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/Retry_Script.cs) 플레이어가 죽을 경우 게임 씬을 재시작 하는 버튼이다.
            
## 버그 리포트

## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```