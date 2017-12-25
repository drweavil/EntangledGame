using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[System.Serializable]
public class Template {
	public List<TemplateSquad> squads = new List<TemplateSquad>(); 

	public int GetTemplatePointsCount(){
		return squads.Count * TemplateSquad.squadMinimumPointsCount;
	}

	public static Template GetTemplateByPointsCount(int pointsCount){
		List<Template> templates = new List<Template> ();

		List<int> templateIDs = new List<int> (new int[] {0, 1, 2, 3, 4,5,
			6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,
			28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,
			49,50,51,52,53});

		foreach (int id in templateIDs) {
			templates.Add(GetTemplateByID(id));

		}

		int maximumSquadsCount = (int)(System.Math.Floor (pointsCount/(float)TemplateSquad.squadMinimumPointsCount));
		//Debug.Log (maximumSquadsCount);
		List<Template> validTemplates = templates.FindAll(t => t.squads.Count <= maximumSquadsCount);
		int index = Random.Range (0, validTemplates.Count);
		Template finalTemplate = validTemplates[index];


		return finalTemplate;
	}

	public static Template GetTemplateByID(int id){
		MethodInfo method = typeof(Template).GetMethod ("GetTemplate_" + id.ToString());
		ParameterInfo[] methodParams = method.GetParameters ();
		List<object> finalMethodParams = new List<object> ();
		foreach (ParameterInfo methodParam in methodParams) {
			finalMethodParams.Add (methodParam.DefaultValue);
		}
		return (Template)method.Invoke (null, null);
	}

	public static Template GetStandartTemplate(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0, 0);
		squad1.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad1);
		return template;
	}

	public static Template GetTemplate_0(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0, 0);
		squad1.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0);
		squad2.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad2);

		return template;
	}

	public static Template GetTemplate_1(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0, 0);
		squad1.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 10f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}


	public static Template GetTemplate_2(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 0f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 10f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);


		return template;
	}


	public static Template GetTemplate_3(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 0f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}


	public static Template GetTemplate_4(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 10f);
		squad4.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_5(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 0f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_6(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}


	public static Template GetTemplate_7(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 5f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}


	public static Template GetTemplate_8(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad2);

		return template;
	}


	public static Template GetTemplate_9(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 1f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 5f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_10(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_11(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 10f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_12(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 10f);
		squad4.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 15f);
		squad5.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (5f, 15f);
		squad6.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad6);


		return template;
	}


	public static Template GetTemplate_13(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 10f);
		squad5.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (5f, 10f);
		squad6.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad6);

		return template;
	}


	public static Template GetTemplate_14(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_15(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 10f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 10f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_16(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 10f);
		squad4.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 10f);
		squad5.endPoint = new Vector2 (9f,14f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (0f, 15f);
		squad6.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad6);

		return template;
	}


	public static Template GetTemplate_17(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}


	public static Template GetTemplate_18(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 10f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);
		return template;
	}


	public static Template GetTemplate_19(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}


	public static Template GetTemplate_20(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_21(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 10f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_22(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 10f);
		squad5.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (5f, 10f);
		squad6.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad6);

		TemplateSquad squad7 = new TemplateSquad ();
		squad7.startPoint = new Vector2 (0f, 15f);
		squad7.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad7);

		TemplateSquad squad8 = new TemplateSquad ();
		squad8.startPoint = new Vector2 (5f, 15f);
		squad8.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad8);

		return template;
	}


	public static Template GetTemplate_23(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 0f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_24(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 0f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);
	
		return template;
	}


	public static Template GetTemplate_25(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_26(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 10f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);


		return template;
	}


	public static Template GetTemplate_27(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_28(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 10f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_29(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_30(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_31(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 10f);
		squad4.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_32(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 10f);
		squad4.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 15f);
		squad5.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (5f, 15f);
		squad6.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad6);

		return template;
	}


	public static Template GetTemplate_33(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 10f);
		squad4.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 10f);
		squad5.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (0f, 15f);
		squad6.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad6);

		TemplateSquad squad7 = new TemplateSquad ();
		squad7.startPoint = new Vector2 (5f, 15f);
		squad7.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad7);

		return template;
	}


	public static Template GetTemplate_34(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 10f);
		squad5.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (0f, 15f);
		squad6.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad6);

		TemplateSquad squad7 = new TemplateSquad ();
		squad7.startPoint = new Vector2 (5f, 15f);
		squad7.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad7);

		return template;
	}


	public static Template GetTemplate_35(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_36(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f,0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f,5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 10f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 10f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_37(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad2);

		return template;
	}


	public static Template GetTemplate_38(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 15f);
		squad2.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad2);


		return template;
	}


	public static Template GetTemplate_39(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}


	public static Template GetTemplate_40(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}


	public static Template GetTemplate_41(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);


		return template;
	}


	public static Template GetTemplate_42(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}


	public static Template GetTemplate_43(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 10f);
		squad4.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 10f);
		squad5.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (0f, 15f);
		squad6.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad6);

		return template;
	}


	public static Template GetTemplate_44(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 5f);
		squad3.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 10f);
		squad4.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 10f);
		squad5.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (0f, 15f);
		squad6.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad6);

		TemplateSquad squad7 = new TemplateSquad ();
		squad7.startPoint = new Vector2 (5f, 15f);
		squad7.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad7);

		return template;
	}


	public static Template GetTemplate_45(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 10f);
		squad5.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (5f, 10f);
		squad6.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad6);

		TemplateSquad squad7 = new TemplateSquad ();
		squad7.startPoint = new Vector2 (0f, 15f);
		squad7.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad7);


		return template;
	}


	public static Template GetTemplate_46(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 0f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);


		return template;
	}


	public static Template GetTemplate_47(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 0f);
		squad4.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 10f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_48(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 9f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 10f);
		squad2.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 0f);
		squad3.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_49(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_50(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 5f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (5f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_51(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 15f);
		squad5.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad5);

		return template;
	}


	public static Template GetTemplate_52(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 5f);
		squad3.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f,5f);
		squad4.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad4);

		TemplateSquad squad5 = new TemplateSquad ();
		squad5.startPoint = new Vector2 (0f, 15f);
		squad5.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad5);

		TemplateSquad squad6 = new TemplateSquad ();
		squad6.startPoint = new Vector2 (5f, 15f);
		squad6.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad6);

		return template;
	}


	public static Template GetTemplate_53(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 10f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}

	public static Template GetTemplate_54(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 15f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);


		return template;
	}

	public static Template GetTemplate_55(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 5f);
		squad3.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad3);

		return template;
	}

	public static Template GetTemplate_56(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 0f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}

	public static Template GetTemplate_57(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 15f);
		squad2.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 0f);
		squad3.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);


		return template;
	}

	public static Template GetTemplate_58(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (9f, 4f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (0f, 5f);
		squad2.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (0f, 15f);
		squad3.endPoint = new Vector2 (4f, 19f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (5f, 5f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}

	public static Template GetTemplate_59(){
		Template template = new Template ();

		TemplateSquad squad1 = new TemplateSquad ();
		squad1.startPoint = new Vector2 (0f, 0f);
		squad1.endPoint = new Vector2 (4f, 14f);
		template.squads.Add (squad1);

		TemplateSquad squad2 = new TemplateSquad ();
		squad2.startPoint = new Vector2 (5f, 0f);
		squad2.endPoint = new Vector2 (9f, 9f);
		template.squads.Add (squad2);

		TemplateSquad squad3 = new TemplateSquad ();
		squad3.startPoint = new Vector2 (5f, 10f);
		squad3.endPoint = new Vector2 (9f, 14f);
		template.squads.Add (squad3);

		TemplateSquad squad4 = new TemplateSquad ();
		squad4.startPoint = new Vector2 (0f, 15f);
		squad4.endPoint = new Vector2 (9f, 19f);
		template.squads.Add (squad4);

		return template;
	}
}
