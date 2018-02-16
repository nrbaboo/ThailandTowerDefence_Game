﻿using UnityEngine;

public class StoryHero : MonoBehaviour {

    /*public static string nameHero = "พ่อขุนรามคำแหง";
    public string name;*/
    public GameObject storyH2_1;
    public void Update()
    {
       // name = nameHero;
    }
    public void closeStoryH2_1()
    {
        storyH2_1.SetActive(false);
    }
    /* public void selectHero1_1()
     {
         nameHero = "พ่อขุนรามคำแหง";
         string data = "     พ่อขุนรามคำแหงมหาราช หรือ พญาร่วง หรือ พระบาทกมรเตงอัญศรีรามราช\nเป็นพระมหากษัตริย์พระองค์ที่ 3 ในราชวงศ์พระร่วงแห่งราชอาณาจักรสุโขทัย\nเสวยราชย์ประมาณ พ.ศ. 1822 ถึงประมาณ พ.ศ. 1841\nพระองค์ทรงเป็นกษัตริย์พระองค์แรกของไทยที่ได้รับการยกย่องเป็น \"มหาราช\"\nด้วยทรงบำเพ็ญพระราชกรณียกิจอันทรงคุณประโยชน์แก่แผ่นดิน ทรงรวบรวม\nอาณาจักรไทยจนเป็นปึกแผ่นกว้างขวาง ทั้งยังได้ทรงประดิษฐ์ตัวอักษรไทยขึ้น\nทำให้ชาติไทยได้สะสมความรู้ทางศิลปะ วัฒนธรรม และวิชาการต่าง ๆ\nสืบทอดกันมากว่าเจ็ดร้อยปี";
         ReadTextFile.read(data);
     }
     public void selectHero1_2()
     {
         nameHero = "พ่อขุนศรีอินทราทิตย์";
         string data = "    พ่อขุนศรีอินทราทิตย์เมื่อครั้งยังเป็น\nพ่อขุนบางกลางหาวได้ร่วมมือกับพ่อขุนผาเมือง\nเจ้าเมืองราดแห่งราชวงศ์ศรีนาวนำถุม\nรวมกำลังพลกันกระทำรัฐประหาร\nขอมสบาดโขลญลำพง \n    โดยพ่อขุนบางกลางหาวตีเมือง\nศรีสัชนาลัยและเมืองบางขลงได้และยกทั้งสองเมืองให้พ่อขุนผาเมืองส่วนพ่อขุนผาเมืองตีเมืองสุโขทัยได้ก็ได้มอบเมืองสุโขทัยให้พ่อขุนบางกลางหาว\nพร้อมพระขรรค์ชัยศรีและพระนาม \"ศรีอินทรบดินทราทิตย์\"ซึ่งได้นำมาใช้\nเป็นพระนาม ภายหลังได้กลายเป็น ศรีอินทราทิตย์\nในกลางรัชสมัยทรงมีสงครามกับขุนสามชนเจ้าเมืองฉอด ทรงชนช้างกับขุนสามชนแต่ช้างทรงพระองค์ได้เตลิดหนีดังคำในศิลาจารึกว่า \"หนีญญ่ายพ่ายจแจ๋น\"\nขณะนั้นพระโอรสองค์เล็กมีพระปรีชาสามารถได้ชนช้างชนะขุนสามชนภายหลังจึงทรงเฉลิมพระนามพระโอรสว่า รามคำแหง";
         ReadTextFile.read(data);
     }
     public void selectHero1_3()
     {
         nameHero = "พ่อขุนผาเมือง";
         string data = "         พ่อขุนผาเมืองเป็นบุคคลที่มีความสำคัญที่สุดผู้หนึ่งในการก่อตั้งอาณาจักรสุโขทัยเป็นผู้นำอพยพไพร่พลจากบริเวณลุ่มน้ำคาย เมืองเชียงทอง หรือล้านช้าง หลวงพระบาง นำไพร่พลมาตั้งเมืองใหม่ริมลำน้ำพุง ตั้งแต่บ้านหนองขี้ควาย มาจนถึงบริเวณวัดกู่แก้ว สถาปนาอาณาจักรขึ้นให้เรียกว่าเมืองลุ่ม อาณาจักรแห่งนี้เดิมอยู่ในเขตอิทธิพลของขอม\nนอกจากนั้นยังปรากฏหลักฐานในนิทานโบราณคดีของสมเด็จกรมพระยาดำรงราชานุภาพที่ทรงสันนิษฐานว่า เหตุจะเกิดเมืองหล่มเก่า เห็นจะเป็นด้วยพวกราษฎรที่หลบหนีภัยอันตรายในประเทศล้านช้าง มาตั้งซ่องมั่วสุมกันอยู่ก่อน แต่เป็นที่ดินดีมีน้ำบริบูรณ์เหมาะแก่การทำเรือกสวนไร่นาและเลี้ยงโคกระบือ จึงมีพวกตามมาอยู่มากขึ้นโดยลำดับจนเป็นเมืองแต่เป็นเมืองมาครั้งสุโขทัย มีปรากฏในหลักศิลาจารึกของพ่อขุนรามคำแหงว่า เมืองลุ่ม ต่อมาภายหลังมาเรียกว่าเมือง หลุ่ม และยังเป็นอีกท่านที่กอบกู้แผ่นดินเอาไว้";
         ReadTextFile.read(data);
     }*/
}
