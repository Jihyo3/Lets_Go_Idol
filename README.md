# 러브라이브! :: 스쿨 아이돌 개발자 프로젝트
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
 
#### 스쿨 아이돌 개발자 프로젝트

## Live  #2:주요 기능 설명

1. 로그인
   * 만약 목록에 만들어져있는 아이디와 비밀번호가 없다면 메인 게임시작씬으로 넘어가지 못합니다.
   * 아이디와 비밀번호를 입력받아 각각 유저의 아바타 를 가지고 메인 게임시작씬으로 넘어갑니다
2. 아이디생성
   * 아이디와 비밀번호를 입력받은뒤 각각 아이디에따른유저의 JSON 파일을 생성합니다.
3. 캐릭터선택
   * 아이디를 생성할때 유저 아바타를 선택하고 선택한아바타의 정보를 JSON파일로 저장합니다.
4. 게임 시작
   * 각각 유저의 아이디에 따른 Player Object 를 생성한뒤 각각 필요한 GameObject를 연동합니다
   * 연동이 끝나면 이제 Falling Object 가 하늘에서 떨어지기 시작합니다.
5. 게임 아이템
   * 시간이 지날때마다 Falling Object 사이에 ItemObject 가 하나씩 떨어집니다.
   * 각각 아이템은 고유의 효과를 지닙니다.  
6. 오브젝트 제거
   * 특정 아이템을 획득시 캐릭터 근처의 Falling Object를 감지하고
   * 키입력시 아이템을 소모하여 Falling Objcet 를 제거합니다.  
7. 추가 장애물
   * 게임에서 시간이 흐를때 랜덤한 이벤트가 발생하고 게임 플레이를 방해합니다
8. 유저 아바타별 능력
   * 각각 유저 아바타마다 키입력시 발생하는 Skill 기능을 구현했습니다
9. 오브젝트 충돌
   * Player 와 Falling Object 가 충돌한다면 현재점수를 저장하고 게임오버 씬으로 넘어갑니다.
10. 게임 오버
    * 각각 ID 별로 저장되어있는 최고점수와 현재점수를 비교하여 최고점수를 저장합니다.
11. 재시작
    * 게임오버 씬에서 처음으로 , 다시하기 버튼을 선택하면 씬을 다시 불러옵니다.

## Live #3:시연 영상
https://studio.youtube.com/video/ouXbAyGr-U8/edit (미편집 원본영상)
https://studio.youtube.com/video/1NjzXURzaC0/edit
