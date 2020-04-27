export { PostData, GetData, DeleteData, PutData };
export { default as DateFormat } from './DateFormat'

const PostData = async (url, data) => {
  // Default options are marked with *
  try {
    const response = await fetch(url, {
      body: JSON.stringify(data), // must match 'Content-Type' header
      headers: {
        'content-type': 'application/json'
      },
      method: 'POST', // *GET, POST, PUT, DELETE, etc.
    });
    const responseJson = await response.json();
    return responseJson;
  } catch (error) {
    console.error(error)
  }
};

const GetData = async (url, token) => {
  try {
    const response = await fetch(`${url}?token=${token}`);
    const responseJson = await response.json();
    return responseJson;
  } catch (error) {
    console.error(error);
  }
}

const DeleteData = async (url) => {
  // Default options are marked with *
  try {
    const response = await fetch(url, {
      method: 'DELETE', // *GET, POST, PUT, DELETE, etc.
    });
    const responseJson = await response.json();
    return responseJson;
  } catch (error) {
    console.error(error)
  }
};


const PutData = async (url, data) => {
  // Default options are marked with *
  try {
    const response = await fetch(url, {
      body: JSON.stringify(data), // must match 'Content-Type' header
      headers: {
        'content-type': 'application/json'
      },
      method: 'PUT', // *GET, POST, PUT, DELETE, etc.
    });
    const responseJson = await response.json();
    return responseJson;
  } catch (error) {
    console.error(error)
  }
};