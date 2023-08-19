# DAGlyn
DAGlyn: Avalonia 기반의 고급 에디터로, 방향성 비순환 그래프(DAG)를 활용해 데이터 흐름을 디자인하고 시각화합니다. 
직관적인 노드 기반 GUI 상호작용에 최적화되어 효율적인 데이터 처리 워크플로우를 제공합니다.

## 현재 발생 문제점.
~~8/11/23 렌더링이 안되는 문제가 발생했다. WPF 에서는 Canvas 에서 잘 렌더링이 되었는데, Avalonia 에서의 Canvas 문제인지, 아니면 나의 코드가 문제인지 파악해야한다.~~  
~~8/12/23 렌더링이 안되는 문제는 Connection 의 문제점이라고 판단이 된다.~~      
~~8/12/23 초기화 문제 해결했다. 렌더링 되게 일단 완성했다. 아직 잠재적인 문제점이 있지만 일단 렌더링은 된다.~~ 
~~8/14/23 Node 바인딩 문제  
-- Connector 와 Connector 의 이름을 연결 시켜야 하는데, Compiled Binding 부분에서 잘 안됨. Binding 부분의 이해력 부족.  
-- ItemsControl 의 ItemSource 에 넣은 Item 의 내용을 ItemTemplate 에서 정의 한 ContentPresenter 에 이름으로 바인딩 시켜야 한다.~~  
8/19/23 ContentPresenter 바인딩이 안되는 문제가 발생했다.  
```xaml
<Canvas Width="800" Height="450" DataContext="{Binding Lists }">
	<controls:ItemContainer Width="20" Height="50" Content="{Binding}" Canvas.Left="20" Canvas.Top="20">
		<controls:ItemContainer.ContentTemplate>
			<DataTemplate x:DataType="controls:ConnectionsViewModel">
				<TextBlock Text="{Binding Lists}" Foreground="Red"/>
			</DataTemplate>
		</controls:ItemContainer.ContentTemplate>
	</controls:ItemContainer>
</Canvas>
```

## 개발 진행 사항 
8/13/23 Node 를 일차적으로 테스트용으로 개발 진행중   
-- UI 구현을 80% 이상 완성도로 완성한 후, Editor 로 넘어간다.

8/15/23 Node 에 들어가는 Connector 를 구현 시작.    
~~-- Anchor 의 위치값을 부모로 부터 가져오는 것을 작성해야 한다.~~  
-- Node 를 저장할 수 있는 Container 를 만들어야 하고, 이 Container 는 위치값을 가져야 한다.  
-- Container 를 독립적으로 만들지 생각해봐야 한다.  
-- 일단 Canvas 에 넣어서 테스트 한번 진행하고, Connector 를 담을 수 있고, 위치 값을 가지는 Container 를 제작한다.  
~~8/16/23 Connector 에서 이벤트들을 구현한다. 이 이벤트를 통해서 부모에서 핸들러를 구현해서 사용할 수 있도록 한다.~~  


![node 참고이미지 - 구현 후 삭제 예정](images/ref01.png)
