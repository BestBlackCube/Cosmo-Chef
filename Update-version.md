# Cosmos-Chef 클라이언트 개발 2.3.2v
## 기능 설명
방해물 소환을 다음스테이지를 향해 갈 수록, 게임 난이도가 증가하는 시스템을 추가.

- ## FoodDrop_Script.cs
   - 1-3, 4-6 스테이지 2개로 나우어 1-3스테이지에서는 가로의 방해물만 나오게, 4-6스테이지에서는 가로, 세로에서 나오게 수정

## 버그 리포트

## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```

# Cosmos-Chef 클라이언트 개발 2.3.1v
## 기능 설명
게임 플레이를 알려주는 조작키 가이드 UI와 Player_Script의 플레이어 이동 코드 수정

- ## 플레이어
   - ### 이동 코드
      이전 플레이어 이동코드의 불필요한 조건문 식을 없애고 직렬로 변경
   - ### 스테이지 포탈
      스테이지 포탈의 조작키를 위쪽 방향키에서 스페이스 바 키로 변경

## 버그 리포트

## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```

# Cosmos-Chef 클라이언트 개발 2.2.1v
## 기능 설명
이전 1.1.0v 버전에서 제작한 횡 스크롤 게임 시스템을 이후 기획을 전부 갈아 엎어 새로운 시스템  
탄막 플랫포머 게임으로 시스템으로 개편하여 기존에 있던 기능들을 일부 살려 제작하였습니다.

메인화면, 인게임, 엔딩 화면 3가지가 있으면 인게임중엔 게임을 플레이가 가능한 1-6스테이지가 존재합니다.

- ## 플레이어
   - ### [Player_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/Player/Player_Script.cs)
      - 기존의 AutoMove 기능을 삭제하고, 기존 기능들중 2D 플랫포머 게임에 사용 할 기능들만 사용하여  
      개편 하였다.

   - ### [좌우 이동](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/Player/Player_Script.cs#L156-L188)
      - 한쪽 방향키를 누르고 반대 방향키를 누를 경우, 처음에 눌렀던 이동 키가 덮어 씌워지는 경우가 있다.  
      이를 방지하기 위해서 한쪽 방향키를 누를경우 bool함수를 이용하여 반대 방양키를 눌러도 덮어 씌우지 못하게 사전에 방지한다.
   - ### [점프](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/Player/Player_Script.cs#L229-L235)
      - 점프를 만들때는 RaycastHit2D를 사용하는게 직관적으로 만들기 쉽지만, [BoxCollider2D](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/Player/Player_Script.cs#L39-L79)를 사용하여 점프 시스템을 구현해 보았다.  
      
         LayerMask를 사용하여 기본상태: Player, 점프 상태: PlayerJump, 점프후 떨어질때: PlayerCheck 3가지로  
         되어 있고, 플레이어가 점프를 하게 된다면 OnTriggerStay2D로 플레이어 캐릭터가 점프를 할때  
         LayerMask가 바뀌면서 PlayerCheck 상태에서 땅을 밟게 되면 점프 상태가 풀린다.
- ## 클리어 목표 아이템
   - ### [Food_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/Food_Script.cs)
      클리어 목표를 달성하기 위한 아이템을 수집 기능이며, 복제된 아이템의 이름을 토대로 switch문을 통해 입력된 이름에 따라 FoodTory_Script.cs의 카운트가 증가한다.  
      또한 5초 타이머를 제작하여 5초 이상일 경우 복제된 아이템은 삭제한다.
   - ### [FoodDrop_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/FoodDrop_Script.cs)
      - [클리어 목표 소환](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/FoodDrop_Script.cs#L39-L87)  
      prefab 오브젝트를 복제하여 인게임 필드에 소환하는 기능이며, Random함수를 통해 소환할 아이템과,  
      소환할 위치를 선정하여 소환한다.  
      (단 해당 위치에 아이템이 있거나 플레이어가 소환위치에 있다면 소환을 스킵한다.)

      - [방해물 소환](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/FoodDrop_Script.cs#L89-L113)  
         방해물을 소환하는 기능이며, 상단과 우측에서 소환되어 하단과 좌측으로 이동한다.  
         이동중 플레이어를 닿게 되면 플레이어의 Hp가 닳게 닳게된다.

         [방해물 이동 및 충돌 감지](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/Spike_Script.cs)

   - ### [FoodTory_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/Player/FoodTory_Script.cs)
      - 클리어 목표에 사용되는 카운트와 달성 후 다음 스테이지로 넘어 갈 수 있는 포탈을 켜는 기능이다.  
         각 스테이지가 시작 했을때 내부 타이머가 실행되고, 클리어 목표의 마지막 아이템을 수집 하게 된다면  
         내부 타이머가 정지하고, TMPro에 기록이 기입된다.  
         또한 클리어 목표보다 더 많은 아이템을 수집 하게 된다면 반대로 플레이어의 Hp가 닳게 된다.
 - ## 엔딩 화면
   - ### [End_Script.cs](https://github.com/BestBlackCube/Cosmo-Chef/blob/main/Cosmo%20Chef/Assets/2D%20Scroll%20Game/public%20Script/End_Script.cs)
      - 게임 씬에서 마지막 스테이지의 이동 포탈을 타게 되면 엔딩 씬으로 넘어와 화면이 전환된다.  
         10초 후 자동으로 메인 화면 씬으로 갈 수 있지만, 엔딩 화면에서 ESC키 3초 이상을 누르면 메인 화면  
         씬으로 강제 전환 할 수 있다.

## 버그 리포트

## 버전 표기법 (Semantic Versioning)
```
[주 버전].[부 버전].[수 버전]
   0   .   0   .   0

- 주 버전: 하위 호환성이 깨지는 변경
- 부 버전: 하위 호환성 유지하며 기능 추가
- 수 버전: 하위 호환성 유지하며 버그 수정
```

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