# angular-efcore
Midlleware C# .Net Core 2.2 com API Rest, ORM Entity e Identity Framework, autenticação JWT, persistência MSSQL Server e frontend Angular 7

Originalmente criado por Vinícius de Andrade "Seja Fullstack com Asp.NET Core 2, Angular 7, EF Core 2" https://www.udemy.com/share/100QgoBEsTc15QQX4=/

<h4>Tecnologias</h4>
<ul>
  <li>.NET Core 2.2</li>
  <li>.NET Entity Core Framework</li>
  <li>.NET Identity Core Framework </li>
  <li>Autenticação JWT</li>
  <li>MSSQL Server</li>
  <li>Angular 7</li>
 </ul>

 <h4>Requisitos</h4>
 <ul>
  <li>.NET Core 2.2 (https://dotnet.microsoft.com/download/dotnet-core/2.2)</li>
  <li>Node.js (https://nodejs.org/en/download/) </li> 
  <li>MSSQL Server (https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) </li>
 </ul>

 <h4>Como usar</h4>
 <h5>Preparar Banco de dados (ProAgil.Repository)</h5>
 <ul>
 <li>alterar connectionStrings do banco de dados em appsettings.Development.json</li>
  <li>realizar migrations</li>
  <li>dotnet ef --startup-project ..\ProAgil.WebAPI migrations add helloworld</li>
  <li>dotnet ef --startup-project ..\ProAgil.WebAPI database update<\li>
</ul> 
 <h5>Backend (ProAgil.WebAPI)</h5>
 <ul> 
   <li>executar os comandos no diretório ProAgil.WebAPI</li>
  <li>dotnet restore </li>
  <li>dotnet watch run </li> 
  <li>acessar no navegador ou Postman http://localhost:5000 </li> 
 </ul>
 <h5>Frontend (ProAgil-App)</h5>
 <ul>
  <li>executar os comandos no diretório ProAgil-App</li>
  <li>npm install </li>
  <li>npm build  </li> 
  <li>Instalar CLI Angular (https://cli.angular.io/quickstart): npm install -g @angular/cli</li>
  <li>ng serve -o</li> 
  <li>acessar no navegador localhost:4200 </li> 
 </ul>
 
 <h5>Tela Eventos</h5>
<p><a target="_blank" rel="noopener noreferrer" href="https://user-images.githubusercontent.com/22710963/61652208-d414a600-ac8d-11e9-8f80-c8487e7fce3a.png">
<img src="https://user-images.githubusercontent.com/22710963/61652208-d414a600-ac8d-11e9-8f80-c8487e7fce3a.png" alt="reset" style="max-width:100%;"></a></p> 
 
 <h5>Login</h5>
 <p><a target="_blank" rel="noopener noreferrer" href="https://user-images.githubusercontent.com/22710963/61652753-14285880-ac8f-11e9-8806-b56b95f5fdd3.png">
 <img src="https://user-images.githubusercontent.com/22710963/61652753-14285880-ac8f-11e9-8806-b56b95f5fdd3.png" alt="reset" style="max-width:100%;"></a></p> 
 
 
 <h5>Editar Evento</h5>
 <p><a target="_blank" rel="noopener noreferrer" href="https://user-images.githubusercontent.com/22710963/61652913-6c5f5a80-ac8f-11e9-9073-73fe8a1acd58.png">
 <img src="https://user-images.githubusercontent.com/22710963/61652913-6c5f5a80-ac8f-11e9-9073-73fe8a1acd58.png" alt="reset" style="max-width:100%;"></a></p> 
 
 
 <h4>Pacotes Angular instalados</h4>
  <ul>
 <li>npm install -g @angular/cli (Instalar CLI Angular (https://cli.angular.io/quickstart) )</li>
  <li>npm install bootstrap (Instalar Bootstrap (https://getbootstrap.com.br/docs/4.1/getting-started/download/)) </li>
  <li>npm install ngx-bootstrap --save (Instalar NGX Bootstrap (https://valor-software.com/ngx-bootstrap/#/))</li> 
  <li>npm install --save-dev @fortawesome/fontawesome-free (Instalar Fonte Awesome (https://fontawesome.com/how-to-use/on-the-web/setup/using-package-managers))</li> 
  <li> npm install ngx-toastr --save
npm install @angular/animations --save (Instalar Notificações (https://www.npmjs.com/package/ngx-toastr)) </li> 
  
  <li>npm i @auth0/angular-jwt (Instalar JWT Angular)</li>
  <li>ng g g auth/auth (Instalar Angular Guard) </li> 
  <li>ng add ngx-bootstrap --component tabs (Instalar Tabs (https://valor-software.com/ngx-bootstrap/#/tabs))</li>  
  <li>npm install --save ngx-mask (Instalar Mask (https://www.npmjs.com/package/ngx-mask))</li>
  <li>npm i ngx-currency (Instalar Mascara dinheiro)</li>
 </ul>
  
 

 
 
