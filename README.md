# Monster Outbreak / ver.미래관

## 프로젝트 설명
- **컨셉**   
    현실세계에 몬스터 게이트가 열리고, 서울과기대 미래관을 지키는 AR게임


## 실행 방법
1. 첨부된 apk파일 실행 (안드로이드에서만 가능)
2. 소스코드를 유니티에서 직접 빌드하여 실행

## 주요 구현 기능

1. **상호작용 화면**

- 시작화면, 재정비 화면
- 게임 시작을 눌러 시작
- 재정비 시간에는 **HP회복(미래관 수리)** 와 **탄알 회복** 중 1가지를 선택할 수 있다.
![스크린샷 2024-05-25 221845](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/845e544d-6a89-4793-858a-c1d132bf46d7)

- 중간 클리어, 게임 오버, 승리

![스크린샷 2024-05-25 222404](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/1447f6ac-05ba-490c-be3d-ed2626c043df)
<br>

2. **웨이브(스테이지) 별 몬스터 랜덤 스폰**

- 1차 웨이브 : 알파킹 10마리

![스크린샷 2024-05-25 220135](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/9394458b-027d-442d-90ad-ecf7bdcd243e)

- 2차 웨이브 : 피죤 20마리

![스크린샷 2024-05-25 231111](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/05fb0d1a-575d-4195-b449-1e8009842f8b)

- 3차 웨이브 : 드래곤 30마리

![스크린샷 2024-05-25 231149](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/65a77b7d-5049-4e07-a0d3-53e026fb9b09)

<br>

3. **총기**

- 발사 버튼을 눌러 총 발사 (발사 시 폰 진동 효과)
- 장전 버튼을 눌러 장전
- 조준점에 몬스터가 들어올 시 붉어짐 <br>
![스크린샷 2024-05-25 222318](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/ae270e3f-76cf-47a1-94c5-9067a235d6a2)
![스크린샷 2024-05-25 221342](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/7b56ade6-aabc-41e5-a55b-e1773dfed605)

- 총 스텟

![스크린샷 2024-05-25 231655](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/1ca8ce20-4525-4511-aa17-b8a4310f0f2e)
<br>

4. **적 몬스터**

- 알파킹, 드래곤, 피죤

![스크린샷 2024-05-25 222654](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/36bbd909-d0d5-43a8-baae-0ba5e1a93620)

- 몬스터 스텟

![스크린샷 2024-05-25 223056](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/88fcb394-6749-41b0-89ed-77302299e7e6)
<br>

5. **미니맵**
- RawImage와 카메라를 활용하여 위에서 아래로 비추어 구현
- 몬스터 프리펩에 원 이미지를 넣었지만 Layer를 이용하여 실제 게임 화면에는 안보임 (미니맵에서만 보임)
- 빨간색 : 몬스터, 파란색 : 미래관, 초록색 : 플레이어

![스크린샷 2024-05-25 223449](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/36cbe3bd-e153-46ef-a19a-7d6d904e360a)
<br>

6. **경고창**

- 탄알 부족 시, 미래관이 공격받을 시 경고창을 띄움
![스크린샷 2024-05-25 230038](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/6b57c16a-a3f1-4337-80f7-167c616a8c45)

## 에셋 정보

- 몬스터
https://quaternius.com/packs/ultimatemonsters.html

- 몬스터 사운드
https://assetstore.unity.com/packages/audio/sound-fx/monster-sfx-111518-132868

- 피격 이펙트 (총 발사, 몬스터 타격)
https://assetstore.unity.com/packages/vfx/particles/hit-impact-effects-free-218385

- 총
https://kenney.nl/assets/blaster-kit

- 총 사운드
https://assetstore.unity.com/packages/audio/sound-fx/sci-fi-guns-sfx-pack-181144#description

- 조준점
https://kenney.nl/assets/crosshair-pack

- UI
https://assetstore.unity.com/packages/2d/gui/gui-pro-fantasy-rpg-170168

- 폰트
https://noonnu.cc/font_page/1358
<br>

![스크린샷 2024-05-25 225721](https://github.com/JisubShim/Monster_Outbreak-AR/assets/118372554/47863d01-8876-4917-aa0e-894cbf7950ce)

## 기타 정보

- 개발 언어 및 엔진 : C#, Unity 2022.3.21f1

- Unity의 AR foundation 플러그인을 활용하여 제작

- 에셋은 저작권 상의 문제로 인해 gitignore 하였습니다.

- 이 프로젝트는 MIT 라이선스로 배포되며, 상세한 라이선스 정보는 LICENSE 에서 확인할 수 있습니다.

*오류 및 버그 수정 문의 : jisub5322@naver.com*