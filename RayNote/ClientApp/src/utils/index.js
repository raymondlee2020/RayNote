export { PostData, GetData };

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

const GetData = async (url) => {
  try {
    const response = await fetch(url);
    const responseJson = await response.json();
    return responseJson;
  } catch (error) {
    console.error(error);
  }
}