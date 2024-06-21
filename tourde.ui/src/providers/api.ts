import axios from "axios";

const axiosInstance = axios.create({
  baseURL: 'https://localhost:7067/api'
});

export default axiosInstance;