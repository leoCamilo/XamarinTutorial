# Xamarin Tutorial for dummies

O objetivo desse app é realizar uma busca interativa de locais utilizando a api do [google places](https://developers.google.com/places/?hl=pt-br), onde é possivel abordar conceitos básicos como:

 - construção de uma aplicação para ambas as plataformas
 - criação de uma página e de componentes visuais
 - consumo de um rest por meio de uma classe de requisição http
 - conversão de JSON em classes
 
 tutorial:
 
 Para a realização desse tutorial é necessário o Visual Studio e o Xamarin instalado, além do [Android SDK](https://developer.android.com/studio/index.html?hl=pt-br) ou [XCode](https://developer.apple.com/xcode/) dependendo da plataforma que será testado.
 
 - criação do projeto:
 
 Criaremos primeiramente um projeto ```Cross Platform App``` com o Xamarin
<p>
  <img src="/screenshots/CreateProject.png">
</p>

Utilizaremos nesse tutorial um app em branco, utilizando a tecnologia ```PCL (Portable Class Library)```
<p>
  <img src="/screenshots/CreateProject2.png">
</p>

- instalando dependências

Nem todas as ferramentas vem inseridas no Framework, por isso a plataforma .NET conta com um gerenciador de Plugins, o [Nuget](https://www.nuget.org/), nesse tutorial será utilizado dois pacotes, o [Newtonsoft.JSON](http://www.newtonsoft.com/json) para serialização do json, e a [Microsoft HTTP Client](https://www.nuget.org/packages/Microsoft.Net.Http/) para utilização da ferramenta de requisição http em uma classe portable.

Para acessar o Gerenciador Nuget.
<p>
  <img src="/screenshots/Nuget.png">
</p>

Onde é possivel pesquisar os pacotes.
<p>
  <img src="/screenshots/Nuget2.png" width="45%">
  <img src="/screenshots/Nuget4.png" width="45%">
  
</p>

E instalalos (somente é necessário instala-los no projeto portable)
<p>
  <img src="/screenshots/Nuget3.png" width="45%">
  <img src="/screenshots/Nuget5.png" width="45%">
</p>

após isso crie os diretórios e a disposição das classes como achar melhor
<p>
  <img src="/screenshots/CreateFolder.png">
  <img src="/screenshots/CreateClass.png">
  <img src="/screenshots/CreateClass2.png">
</p>

Nesse tutorial foram utilizados as seguintes nomeclaturas:
 - [SearchPlace](/XamarinTutorial/XamarinTutorial/src/view/pages/SearchPlace.cs)
 - [GooglePlaceResult](/XamarinTutorial/XamarinTutorial/src/model/domain/GooglePlaceResult.cs)
 - [Prediction](/XamarinTutorial/XamarinTutorial/src/model/domain/Prediction.cs)

As classes ```GooglePlaceResult``` e ```Prediction``` são para a realização da Deserialização do json:
```csharp
using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinTutorial.src.model.domain
{
    public class Prediction
    {
        [JsonProperty] <---- AQUI DEFINE A PROPRIEDADE JSON
        public string id { get; set; }
        
        ...
```

A classe ```SearchPlace``` conta com os elementos visuais e a função de busca da api, não façam isso em casa, isso foi feito por profissionais, com o equipamento adequado =):
```csharp
  var stack = new StackLayout();  <--- Empilha os elementos
  var search = new SearchBar();   <--- Barra de Busca
  
  ...

  stack.Children.Add(search);     <--- adciona os elementos na pilha
  
  ...
  
  search.TextChanged += async (sender, e) =>      <------ operador lambda para atribuição de função a um evento
  {
      try
      {
          var searchBar = (SearchBar)sender;
          var client = new HttpClient();
          ...
```

Também é necessário criar uma chave do google para utilizar a API, ela pode ser criada [aqui](https://developers.google.com/places/web-service/?hl=pt-br):
```csharp
  private const string API_KEY = "your api key";
```

Por ultimo, troque a referência da página principal da classe App.xaml.cs para sua classe:
 ```csharp
  public App()
  {
      InitializeComponent();
      MainPage = new SearchPlace();
  }
 ```
 após isso é só executar:
 
 
