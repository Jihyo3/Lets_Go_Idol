# 러브라이브! :: 스쿨 아이돌 개발자 프로젝트
<br/>
<br/>

## Live #1: 팀원소개
* 정지효(팀장님)
   * 캐릭터 담당 
* 윤규석
   * 게임로직 담당
* 유수정
   * 게임화면 , 로그인 , 회원가입 담당
* 박인수
   * 추가장애물 , 오브젝트 제거 담당
* 박의겸
   * 낙하 오브젝트 , 캐릭터 스킬 담당

<br/>
<br/>

## Live  #2: 주요 기능 설명

### 1. 로그인
   * 만약 목록에 만들어져있는 아이디와 비밀번호가 없다면 메인 게임시작씬으로 넘어가지 못합니다.
   * 아이디와 비밀번호를 입력받아 각각 유저의 아바타 를 가지고 메인 게임시작씬으로 넘어갑니다
     ![스크린샷 2024-05-23 122412](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/d580a9c4-8d60-4565-abb3-ff7e668f16d3)

### 2. 아이디생성
   * 아이디와 비밀번호를 입력받은뒤 각각 아이디에따른유저의 JSON 파일을 생성합니다.
### 3. 캐릭터선택
   * 아이디를 생성할때 유저 아바타를 선택하고 선택한아바타의 정보를 JSON파일로 저장합니다.
     ![스크린샷 2024-05-23 121105](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/a6d3d132-16b1-4422-a590-c85b392a8b96)

### 4. 게임 시작
   * 각각 유저의 아이디에 따른 Player Object 를 생성한뒤 각각 필요한 GameObject를 연동합니다
   * 연동이 끝나면 이제 Falling Object 가 하늘에서 떨어지기 시작합니다.

     
     ![스크린샷 2024-05-22 203624](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/df37c40f-df30-49ff-87aa-46d6b7da9fe9)

### 5. 게임 아이템
   * 시간이 지날때마다 Falling Object 사이에 ItemObject 가 하나씩 떨어집니다.
   * 각각 아이템은 고유의 효과를 지닙니다. (마이크- 특수스킬 추가, 헤드셋- 플레이어 크기 작게 조절, 앨범- 쉴드)
     ![itemss](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/2a34119e-8279-47da-8312-d1b6641ada37)

### 6. 오브젝트 제거
   * 특정 아이템을 획득시 캐릭터 근처의 Falling Object를 감지하고 키입력시 아이템을 소모하여 Falling Objcet 를 제거합니다.
   * 
     ![스크린샷 2024-05-23 123204](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/6fe550f1-4b85-4b38-8fda-17135ceb1aff)


### 7. 추가 장애물
   * 게임에서 시간이 흐를때 랜덤한 이벤트가 발생하고 게임 플레이를 방해합니다.

### 8. 유저 아바타별 능력
   * 각각 유저 아바타마다 키입력시 발생하는 Skill 기능을 구현했습니다
### 9. 오브젝트 충돌
   * Player 와 Falling Object 가 충돌한다면 현재점수를 저장하고 게임오버 씬으로 넘어갑니다.

### 10. 게임 오버
   * 각각 ID 별로 저장되어있는 최고점수와 현재점수를 비교하여 최고점수를 저장합니다.
    
### 11. 재시작
   * 게임오버 씬에서 처음으로 , 다시하기 버튼을 선택하면 씬을 다시 불러옵니다.
   ![스크린샷 2024-05-23 123731](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/a0f0fb6a-383f-4c40-9792-b6ee6ca17b97)

     
### 12. 환경설정 
   * 사운드와 배경이미지를 설정할 수 있습니다.
   ![스크린샷 2024-05-23 121115](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/56e34905-cd1b-4645-a7fe-bdeecb71ced6)

<br/>
<br/>

## Live #3: 시연 영상
*  ### 미편집 원본영상
[![Main](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/582de7fd-21b2-4b76-b540-81e098ac510a)
](https://www.youtube.com/watch?v=ouXbAyGr-U8)

   
* ### 편집 영상
[![Main](https://github.com/Jihyo3/Lets_Go_Idol/assets/141620531/582de7fd-21b2-4b76-b540-81e098ac510a)
](https://www.youtube.com/watch?v=1NjzXURzaC0)
