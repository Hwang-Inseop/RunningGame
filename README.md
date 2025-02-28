# Unity 2D Running Action

## ALIENS
> Unity 2D로 개발한 러닝 액션 게임 개발 실습 팀 프로젝트.  
> 캐릭터 5종, 장착 아이템 3종의 시스템과 스테이지 3종의 컨텐츠가 구현되어있습니다.  
> 내일배움캠프 유니티 입문 주차 팀 프로젝트 2025.02.21 ~ 2025.02.28

## 게임 영상
[![동영상 설명](https://img.youtube.com/vi/YconiN80K4s/0.jpg)](https://www.youtube.com/watch?v=YconiN80K4s)

## 조작
| 키 입력      | 동작    |
|-----------|-------|
| `Z`       | 점프    |
| `X`       | 슬라이드  |
| `Z(공중에서)` | 2단 점프 |

## 주요 기능
### 🎨로비 화면
<img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2FbjiJXZ%2FbtsMxCeMz7g%2Fnt6f7ZabcmQQYEyMHhL4Qk%2Fimg.png" width="500">  

로비 화면에서 캐릭터를 정비하고 게임을 시작할 수 있습니다.

### 👽캐릭터 선택
<img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2FcQ5XIG%2FbtsMylQ9PtM%2FyUGIbsnv9t5y6QXe3kC3R0%2Fimg.png" width="500"> 

로비에서 캐릭터를 클릭하면 캐릭터 선택 화면으로 이동합니다.  
캐릭터는 총 5종류가 있으며, 각 캐릭터는 능력치가 다릅니다.    
캐릭터는 게임 내에서 획득한 코인으로 구매할 수 있습니다.

<img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2FbjwlNl%2FbtsMzuNmrd1%2FENcZxEpfsN0wRUWVUNEaRk%2Fimg.png" width="500">

게임 내에서 획득한 다이아로 캐릭터를 해금할 수 있습니다.  
캐릭터를 선택하면 1번째 주자와 2번째 주자를 선택할 수 있습니다.

### 🏆보물 장착
<img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2FbzBKlz%2FbtsMAjLgnTc%2FSJpVmuX6M3DvNKVeaC8481%2Fimg.png" width="500">

로비에서 보물을 클릭하면 보물 선택 화면으로 이동합니다.  
보물은 총 3종류가 있으며, 각 보물은 능력치가 다릅니다.  
보물은 게임 내에서 획득한 코인으로 구매할 수 있습니다. 

### 🚀스테이지 선택
<img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2FbH3wlh%2FbtsMAsafpfx%2FuZKXM6VppxNW7iYrTHAAU1%2Fimg.png" width="500">

로비에서 스테이지 선택을 클릭하면 스테이지 선택 화면으로 이동합니다.  
스테이지는 총 3종류가 있으며, 각 스테이지는 난이도가 다릅니다.


## 개발
| 이름      | 파트               |
|---------|------------------|
| 황인섭(팀장) | 플레이어 조작, 능력      |
| 박소희     | 플레이어 특수능력, 아이템   |
| 김준혁     | 타이틀 씬, 로비 씬      |
| 윤동영     | 메인 씬 UI, 타이틀 씬 UI |
| 김자은     | 메인 씬 게임로직        |

## 협업 과정
### 데일리 스크럼 공유
<img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2FmldL2%2FbtsMAlh1pRu%2FDoUpuD17OFadwEIKeKHSaK%2Fimg.png" width="700">

데일리 스크럼 공유를 통해 현재 업무 계획, 공정률, 이슈 등을 공유하며 프로젝트를 진행했습니다.

### 화상 회의
<img src="https://img1.daumcdn.net/thumb/R1280x0/?scode=mtistory2&fname=https%3A%2F%2Fblog.kakaocdn.net%2Fdn%2Frl8II%2FbtsMxj0Uvd1%2F7K4Uas8pKKXYgK2G37pgA1%2Fimg.png" width="700">

개발 기간 중 상시 화상 공유를 통해 팀원 간 코드 리뷰와 테스트를 진행하는 것으로  
개발 중 발생하는 문제를 함께 해결했습니다.


## 기술 스택
- Unity 2022.3.17f1
- C#
- DoTween

## 라이선스
| 에셋 이름     |출처| 라이선스        |
|-----------|---|-------------|
| DoTween   |https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676| MIT License |
| BGM 및 효과음 |https://pixabay.com/ko/| MIT License |
|Platformer Pack Redux|https://www.kenney.nl/assets/platformer-pack-redux| CC0         |
|Generic Items|https://www.kenney.nl/assets/generic-items| CC0         |
|UI Pack|https://www.kenney.nl/assets/ui-pack| CC0         |

