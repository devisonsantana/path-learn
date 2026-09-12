import { useState } from "react";
import axios from "axios";
import Message from "./Message";
import Progress from "./Progress";
const FileUpload = () => {
  const [file, setFile] = useState("");
  const [filename, setFilename] = useState("Choose a file");
  const [uploadedFile, setUploadedFile] = useState(null);
  const [message, setMessage] = useState("");
  const [uploadPercentage, setUploadPercentage] = useState(0);
  const onChange = (e) => {
    setFile(e.target.files[0]);
    setFilename(e.target.files[0].name);
  };
  const onSubmit = async (e) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("file", file);
    try {
      const res = await axios.post("/upload", formData, {
        headers: { "Content-Type": "multipart/form-data" },
        onUploadProgress: (progressEvent) => {
          setUploadPercentage(
            parseInt(
              Math.round((progressEvent.loaded * 100) / progressEvent.total),
            ),
          );
          setTimeout(() => {
            setUploadPercentage(0);
          }, 10000);
        },
      });
      const { fileName, filePath } = res.data;
      setUploadedFile({ fileName, filePath });
      setMessage("File Uploaded");
    } catch (err) {
      if (err.response.status === 500) {
        setMessage("There was a problem with the server");
      } else {
        setMessage(err.response.data.msg);
      }
    }
  };
  return (
    <>
      {message && <Message msg={message} />}
      <form onSubmit={onSubmit}>
        <div className="mb-3">
          <label htmlFor="formFile" className="form-label">
            {filename}
          </label>
          <input
            className="form-control"
            type="file"
            id="formFile"
            onChange={onChange}
          />
        </div>

        <Progress percentage={uploadPercentage} />

        <input
          type="submit"
          value="Upload"
          className="btn btn-primary btn-block w-100 mt-3"
        />
      </form>

      {uploadedFile ? (
        <div className="row mt-5">
          <h3 className="text-center">{uploadedFile.fileName}</h3>
          <img
            style={{ width: "100%" }}
            src={`/public/${uploadedFile.filePath}`}
            alt=""
          />
        </div>
      ) : null}
    </>
  );
};

export default FileUpload;
