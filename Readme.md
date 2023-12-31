﻿# DAGlyn
DAGlyn: Avalonia 기반의 고급 에디터로, 방향성 비순환 그래프(DAG)를 활용해 데이터 흐름을 디자인하고 시각화합니다. 
직관적인 노드 기반 GUI 상호작용에 최적화되어 효율적인 데이터 처리 워크플로우를 제공합니다.  

DAGlyn: An advanced editor based on Avalonia, designed to visualize and design data flows using Directed Acyclic Graphs (DAG).   
It's optimized for intuitive node-based GUI interactions, providing an efficient data processing workflow.  

## 현재 발생 문제점 및 개발 진행 사항
~~8/11/23 렌더링이 안되는 문제가 발생했다. WPF 에서는 Canvas 에서 잘 렌더링이 되었는데, Avalonia 에서의 Canvas 문제인지, 아니면 나의 코드가 문제인지 파악해야한다.~~  
~~8/12/23 렌더링이 안되는 문제는 Connection 의 문제점이라고 판단이 된다.~~      
~~8/12/23 초기화 문제 해결했다. 렌더링 되게 일단 완성했다. 아직 잠재적인 문제점이 있지만 일단 렌더링은 된다.~~ 
~~8/14/23 Node 바인딩 문제  
-- Connector 와 Connector 의 이름을 연결 시켜야 하는데, Compiled Binding 부분에서 잘 안됨. Binding 부분의 이해력 부족.  
-- ItemsControl 의 ItemSource 에 넣은 Item 의 내용을 ItemTemplate 에서 정의 한 ContentPresenter 에 이름으로 바인딩 시켜야 한다.~~  
~~8/19/23 ContentPresenter 바인딩이 안되는 문제가 발생했다.~~  
~~8/20/23 바인딩 문제는 해결했는데, Visual Tree 를 검사를 하면 DataTemplate 이하가 렌더링 되지 않는 문제가 발생한다.~~  
~~-- WPF 와 ContentPresenter 바인딩 하는 방식도 다르고, ContentPresenter 의 ContentTemplate 에 DataTemplate 을 적용하는 방식이 다른 것 같다.~~  
~~8/25/23 Connector 가 생기지 않는 문제 발생. xaml 구조의 문제인거 같다. 이거 원인을 파악하고 해결해야 한다.~~    

~~8/13/23 Node 를 일차적으로 테스트용으로 개발 진행중~~     
~~-- UI 형태만 만들고, Editor 로 넘어간 후, Editor 완성 후 디자인적으로 신경쓴다.~~   
~~8/15/23 Node 에 들어가는 Connector 를 구현 시작.~~      
~~-- Anchor 의 위치값을 부모로 부터 가져오는 것을 작성해야 한다.~~  
~~-- Node 를 저장할 수 있는 Container 를 만들어야 하고, 이 Container 는 위치값을 가져야 한다.~~    
~~-- Container 를 독립적으로 만들지 생각해봐야 한다.~~    
~~-- 일단 Canvas 에 넣어서 테스트 한번 진행하고, Connector 를 담을 수 있고, 위치 값을 가지는 Container 를 제작한다.~~    
~~8/16/23 Connector 에서 이벤트들을 구현한다. 이 이벤트를 통해서 부모에서 핸들러를 구현해서 사용할 수 있도록 한다.~~  
~~8/21/23 Connection, Connector, ItemContainer 연결 문제~~  
~~-- 서로 다른 좌표 영역에서 연결시켜야 하고, Connector 와 ItemContainer 는 **Connection 을 담을 수 있는 클래스가 아니다**.~~  
~~-- 어떻게 바인딩 시킬지 고민해야 한다. 좀 어렵다.~~  
8/22/23 **Connector, ItemContainer, Connection 클래스가 각각 독립적으로 설계하고 싶다.** 계속 종속적으로 구현하게 되는데 이것도 어렵다.  
~~8/22/23 Node 에 Connector 연결~~  
~~-- InputConnector 추가, Connector 의 axaml 없애버리고, InputConnector 로 대체. 하지만~~ **이러면 다양한 모습을 할 수 없다라는 단점이 생김.**  
~~8/28/23 초기 Editor 구현~~    
~~8/29/23 VirtualCanvas 구현 필요 및 이를 통해서 OverlayLayer 재 구현 또는 새롭게 구현.~~  

## 현재 DAGlynEditor 를 따로 떼어내서 구현중에 있음.

## 현재 개선해야할 부분에 대한 아이디어(그냥 막씀, 아래 문제 내용에 대한)
~~8/22/23 Node 에 Connector 연결~~  
~~-- InputConnector 추가, Connector 의 axaml 없애버리고, InputConnector 로 대체. 하지만~~ **이러면 다양한 모습을 할 수 없다라는 단점이 생김.** 
```
이 문제 같은 경우는 pending 할때는 그냥 실선으로 중앙에서 나와서 중앙으로 연결 시키는 형태로 해도 될듯하다. 
그리고 연결이 완료 된 이후에는 connector 가 생겨서 쌓이는 형태로 가져가면 될듯하다.

즉, connector 로 연결 시키는 것이 아니라 부분에서 마우스 입력 받아서 처리하는 형태로 가 면될듯하다.
부분이라는 의미는 노드에서 한쪽 면을 차지하는 컨트롤로 이해하면 될듯하다.
```
## 개발 고려 사항
1. 컨트롤들간에 데이터 송신 및 데이터 수신은 이벤트로 처리한다.  

## 향후 개발시 참고사항(그냥 기록용으로, 향후 삭제)
1. Toolbar 같은 경우는 AvaloniaEdit 을 한번 참고해본다.    
2. Connector 의 axaml 없애버리고, InputConnector 로 대체. 하지만 이러면 다양한 모습을 할 수 없다라는 단점이 생김. 이 문제를 향후 처리함.  
3. AvaloniaEdit Utils 에서 ExtensionMethods 일부와 FileReader 를 가지고 왔다. 향후 수정해서 사용한다.   
4. InputConnectorPanel 삭제 예정.  
5. Connector 추가/삭제는 Header 설정 창에서 설정.  
6. Connector 자체가 없어도 된다는 생각도 하고 있다. 하지만 그것은 추후 업데이트 하자.  

## 디자인 참고 및 스케치

![node 참고이미지 - 구현 후 삭제 예정](images/ref01.png)

Footer 에 컨테이너 환경도 넣어야 할듯.
![node 초기 구상 이미지 - 구현 후 삭제 예정](images/init01.png)
