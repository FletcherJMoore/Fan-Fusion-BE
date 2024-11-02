# Fan Fusion - Backend

## Description

Fan Fusion is a fan fiction platform where writers aspiring writers can publish their stories, build an audience, and recieve feedback. At the same time, readers can easily explore and enjoy new stories based on their preferences. 

## Table of Contents

- [Technologies](#technologies)
- [Installation](#installation)
- [API Endpoints](#api-endpoints)
- [Testing](#testing)

## Technologies

- **Programming Language:** C#
- **Framework:** [e.g., Node.js/Express, Django, Flask]
- **Database:** PostgreSQL
- **Authentication:** Firebase
- **Other Tools:** 

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/your-repo.git
   cd your-repo
  
2. Install dependencies:
   ```bash
   npm install  # For Node.js

3.Set up environment variables: 
Create a .env file in the root directory and add the required environment variables 

4. To start the server, run:
 ```bash
npm run dev
```
You can now access the API at http://localhost:3000

## API Endpoints

### Stories
| Method | Endpoint                             | Description                   |
|--------|--------------------------------------|-------------------------------|
| GET    | `/stories`                           | Retrieve all stories          |
| POST   | `/stories`                           | Create a new story            |
| GET    | `/stories/{storyId}`                 | Retrieve a specific story     |
| PUT    | `/stories/{storyId}`                 | Update an existing story      |
| DELETE | `/stories/{storyId}`                 | Delete a story                |
| GET    | `/stories/search`                    | Search story by title         |
| GET    | `/stories/categories/{categoryId}`   | Get stories by category       |
| POST   | `/stories/{storyId}/add-tag/{tagId}` | Add a tag to a story          |
| DELETE | `/stories/{storyId}/add-tag/{tagId}` | Remove a tag from a story     |

### Chapters
| Method | Endpoint                           | Description                   |
|--------|------------------------------------|-------------------------------|
| GET    | `/chapters/{chapterId}`            | Retrieve all stories          |
| POST   | `/chapters`                        | Create a new story            |
| DELETE | `/chapters/{chapterId}`            | Delete a story                |

### Comments
| Method | Endpoint                           | Description                   |
|--------|------------------------------------|-------------------------------|
| GET    | `/comments`                        | Create a comment              |
| DELETE | `/comments`                        | Remove a comment              |

### Users
| Method | Endpoint                           | Description                   |
|--------|------------------------------------|-------------------------------|
| GET    | `/users/checkUser`                 | Checks logged in user         | 
| GET    | `/users/{userId}`                  | Retrieve a specific user      | 


### Tags
| Method | Endpoint                           | Description                   |
|--------|------------------------------------|-------------------------------|
| GET    | `/tags`                            | Retrieve all tags             | 


## Testing
To run tests, use:
```bash
npm test 
```

##Postman Documentation
You can also test our calls on Postman! 
Link: https://www.postman.com/rare-be/fan-fiction-be/collection/xriezl6/fan-fusion
