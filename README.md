
<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

This project is realized for a technical test for the 57 Blocks. This application is developed in C# and it has a connection to MongoDB. It has two controllers, the first one has two operations that permit creating a user in the system and the other for realizing a authentication in database. It works with jwt standard security. The second one is a CRUD system for songs.

<p align="right">(<a href="#top">back to top</a>)</p>



### Built With

* [C# (.NET 6)](https://dotnet.microsoft.com/en-us/)
* [Mongo DB](https://www.mongodb.com/)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

Next prerequisites are necesary.
* Microsoft.AspNetCore.Authentication.JwtBearer
* Microsoft.VisualStudio.Azure.Containers.Tools.Targets
* MongoDB.Driver
* System.IdentityModel.Tokens.Jwt
  

### Installation

_The next steps are necessary for developing in this project_

2. Clone the repo
   ```sh
   git clone https://github.com/maoruiz24/BackendTest.git
   ```
3. Install NuGet packages
4. Enter your Secret in `appsettings.json`
   ```json
   "AppSettings": {
    "Secret": "ENTER YOUR SECRET"
    }
   ```

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

For more detail of API resources and documentation, please execute the project and go to [https://localhost:7186/swagger/index.html](https://localhost:7186/swagger/index.html_)

The credentials to connect to the database are:
- _user:_ musictest
- _password:_ 54lXz14MM5icwfII
- _database:_ Music
- _Connection String_
```Connection String
   mongodb+srv://musictest:54lXz14MM5icwfII@cluster0.0n1vv.mongodb.net/Music?retryWrites=true&w=majority
```    

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Technical test
- [ ] Technical interview

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Ivan Mauricio Ruiz - [https://www.linkedin.com/in/maoruiz24/](https://www.linkedin.com/in/maoruiz24/) - maoruiz24@hotmail.com

Project Link: [https://github.com/maoruiz24/BackendTest](https://github.com/maoruiz24/BackendTest)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* [https://57blocks.io/](https://57blocks.io/)


<p align="right">(<a href="#top">back to top</a>)</p>

