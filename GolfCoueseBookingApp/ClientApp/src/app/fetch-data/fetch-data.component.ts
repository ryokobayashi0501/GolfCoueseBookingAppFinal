//import { Component, Inject } from '@angular/core';
//import { HttpClient } from '@angular/common/http';

//@Component({
//  selector: 'app-fetch-data',
//  templateUrl: './fetch-data.component.html'
//})
//export class FetchDataComponent {
//  public forecasts: WeatherForecast[] = [];

//  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
//      this.forecasts = result;
//    }, error => console.error(error));
//  }
//}

//interface WeatherForecast {
//  date: string;
//  temperatureC: number;
//  temperatureF: number;
//  summary: string;
//}
//[]





//import { Component, OnInit, Inject } from '@angular/core';
//import { HttpClient } from '@angular/common/http';




//@Component({
//  selector: 'app-fetch-data',
//  templateUrl: './fetch-data.component.html',
//  // styleUrls: ['./fetch-data.component.css']
//})
//export class CourseComponent  {
//  public courses: Courses[] = [];
//  //public courseModel: courses = { UserId: 1, CourseName: '', CourseURL: '', Address: '', TelephoneNumber: 0, Description: '' };

//  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
//    this.fetchData();
//  }
//  fetchData() {

//    this.http.get<Courses[]>(this.baseUrl + 'api/course/getItems').subscribe(result => {
//      console.log("list of received products: ", result);
//      this.courses = result.map(Course => ({
//        ...Course,
//        CourseName: Course.CourseName !== "null" ? Course.CourseName : 'Not found',
//       // CourseURL: this.courseModel.CourseURL !== null ? this.courseModel.CourseURL : 'Not Found',
//       // Address: this.courseModel.Address !== null ? this.courseModel.Address : 'Not Found',
//       // TelephoneNumber: this.courseModel.TelephoneNumber !== null ? Number(this.courseModel.TelephoneNumber) : 'Not Found' as unknown as number,
//      //  Description: this.courseModel.Description !== "null" ? this.courseModel.Description : 'Not found',
//        //price: product.price !== null ? Number(product.price) : 'Not Found' as unknown as number,
//       // stock: product.stock !== null ? Number(product.stock) : 'Not Found' as unknown as number,
//        // error handling
//        // for the numbers you state its a number and list it as an unknown number
//      }));
//    }, error => console.error(error));
//  }
//  /*
//  // CourseComponent の addCourse メソッド内
//  addCourse() {
//    this.http.post(this.baseUrl + 'api/course/Post', this.courseModel).subscribe(
//      result => {
//        console.log('Added course:', result);
//        this.fetchData(); // コース一覧を再読み込み
//        this.courseModel = { UserId: 1, CourseName: '', CourseURL: '', Address: '', TelephoneNumber: 0, Description: '' }; // フォームをリセット
//      },
//      error => {
//        console.error('Error adding course:', error);
//      }
//    );
//  }
//  postItem() {
//    // post items, created them as constants and set them to an array of items to post
//    const CourseName = (document.getElementById('nameTextArea') as HTMLTextAreaElement).value;
//    const CourseURL = (document.getElementById('descriptionTextArea') as HTMLTextAreaElement).value;
//    const Address = (document.getElementById('priceTextArea') as HTMLTextAreaElement).value;
//    const TelephoneNumber = (document.getElementById('stockTextArea') as HTMLTextAreaElement).value;
//    const Description = (document.getElementById('stockTextArea') as HTMLTextAreaElement).value;

//    const newItem = { CourseName, CourseURL, Address, TelephoneNumber, Description };

//    this.http.post(this.baseUrl + 'api/course/Post', newItem).subscribe(response => {
//      console.log('item posted correctly', newItem);
//    },
//      error => {
//        console.error('Error adding item', error);
//      });
//  }


//  deleteCourse(id: number | undefined) {
//    if (id === undefined) {
//      console.error('Course ID is undefined');
//      return;
//    }
//    this.http.delete(this.baseUrl + 'api/Course/Delete/' + id).subscribe(result => {
//      this.courses = this.courses.filter(c => c.CourseId !== id);
//    }, error => console.error('Error deleting course:', error));
//  }
//  */

//}
//interface Courses {
//  CourseId?: number;
//  UserId?: number; // Ensure this is included
//  CourseName: string;
//  CourseURL: string;
//  Address: string;
//  Description: string;
//  TelephoneNumber: number;
//}




import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-course',
  templateUrl: './fetch-data.component.html'
})
export class CourseComponent {
  public golfCourses: GolfCourse[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.fetchData();
  }

  fetchData() {
    this.http.get<GolfCourse[]>(this.baseUrl + 'api/course/getItems').subscribe(result => {
      console.log("Received golf courses: ", result);
      this.golfCourses = result.map(course => ({
        ...course,
        CourseName: course.courseName !== "null" ? course.courseName : 'Not found',
      }));
    }, error => console.error(error));
  }

  addGolfCourse() {
    const UserId = (document.getElementById('UserId') as HTMLTextAreaElement).value;
    const CourseName = (document.getElementById('CourseName') as HTMLTextAreaElement).value;
    const CourseUrl = (document.getElementById('CourseURL') as HTMLTextAreaElement).value;
    const Address = (document.getElementById('Address') as HTMLTextAreaElement).value;
    const Description = (document.getElementById('Description') as HTMLTextAreaElement).value;
    const TelephoneNumber = (document.getElementById('TelephoneNumber') as HTMLTextAreaElement).value;

    const newCourse = { UserId, CourseName, CourseUrl, Address, Description, TelephoneNumber }

    this.http.post(this.baseUrl + 'api/course/Post', newCourse).subscribe(() => {
      console.log("added new item correctly" + newCourse);
      this.fetchData();  // Refresh the list after adding
    }, error => console.error(error));
  }

  updateGolfCourse(updatedCourse: GolfCourse) {
    this.http.put(this.baseUrl + 'api/course/Put', updatedCourse).subscribe(() => {
      this.fetchData();  // Refresh the list after updating
    }, error => console.error(error));
  }

  deleteGolfCourse(courseId: number) {
    this.http.delete(this.baseUrl + `api/course/Delete/${courseId}`).subscribe(() => {
      console.log("deleted course with course Id " + courseId);
      this.fetchData();  // Refresh the list after deleting
    }, error => console.error(error));
  }
}

interface GolfCourse {
  courseId: number;
  userId: number;
  courseName: string;
  courseURL: string;
  address: string;
  description: string;
  telephoneNumber: string;
}








