import axios from "axios";

const toggleLoading = (value) => {};

const axiosInstance = (
  contentType = "application/json",
  responseType = "json",
  isShowLoading,
  isShowErrorMessage,
  allowAnonymous
) => {
  if (isShowLoading) toggleLoading(true);

  const instance = axios.create({
    responseType: responseType,
  });

  instance.interceptors.response.use(
    (response) => {
      if (isShowLoading) toggleLoading(false);

      return response;
    },
    (error) => {
      if (isShowLoading) toggleLoading(false);

      if (error.response.status === 401) {
        //handleUnAuthorize();
      } else {
        const data = error.response.data;
        if (isShowErrorMessage) {
          let message =
            error.response.status === 403
              ? "common.forbiddenError"
              : "common.serverError";

          if (data && data.message) {
            message = data.message;
          } else if (typeof data == "string" && data !== "") {
            message = data;
          }

          //showNotification("error", message);
        }
      }

      return Promise.reject(error);
    }
  );

  return instance;
};

export const postAsync = (
  url,
  json = null,
  isShowLoading,
  isShowErrorMessage,
  allowAnonymous
) => {
  return axiosInstance(
    "application/json",
    "json",
    isShowLoading,
    isShowErrorMessage,
    allowAnonymous
  ).post(url, json);
};
